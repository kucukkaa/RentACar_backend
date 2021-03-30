using Business.Abstract;
using Business.BusinessAspects.AutoFac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        //[SecuredOperation("carImage.add, admin")]
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult AddImage(CarImage image)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageLimitExceded(image.CarId));

            if (result != null)
            {
                return result;
            }

            _carImageDal.Add(CarImageCorrection(image).Entity);
            return new SuccessResult(Message.CarImageAdded);
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Delete(CarImage image)
        {
            _carImageDal.Delete(image);
            return new SuccessResult(Message.CarImageDeleted);
        }

        public IDataResult<List<CarImage>> GetCarImages()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetImagesOfACar(int id)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(p => p.CarId == id));
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(CarImage image)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageLimitExceded(image.CarId));
            if (result != null)
            {
                return result;
            }

            _carImageDal.Update(CarImageCorrection(image).Entity);
            return new SuccessResult(Message.CarImageUpdated);
        }

        private IResult CheckIfCarImageLimitExceded(int carId)
        {
            var result = _carImageDal.GetAll(p => p.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult(Message.CarImageLimitExceded);
            }
            return new SuccessResult();
        }

        private  IEntityResult<CarImage> CarImageCorrection(CarImage image)
        {
            if (image.ImagePath == null)
            {
                image.ImagePath = @"C:\ReCapProject-Frontend\CarImages\default.jpg";//DEFAULT JPG OR PNG PATH
            }

            string photoExtension = Path.GetExtension(image.ImagePath);

            if (photoExtension.ToLower() == ".jpg" || photoExtension.ToLower() == ".png")
            {
                string photoName = Guid.NewGuid() + photoExtension;
                
                if (!Directory.Exists(@"C:\ReCapProject-Frontend\CarImages\" + image.CarId))//IF DIRECTORY DOESN'T EXIST
                {
                    Directory.CreateDirectory(@"C:\ReCapProject-Frontend\CarImages\" + image.CarId);
                }
                File.Copy((image.ImagePath), (@"C:\ReCapProject-Frontend\CarImages\" + image.CarId + @"\" + photoName));//COPY PHOTO TO DIRECTORY
                image.ImagePath = @"C:\ReCapProject-Frontend\CarImages\" + image.CarId + @"\" + photoName; 
                image.Date = DateTime.Now;
                
                return new SuccessEntityResult<CarImage>(image);
            }
            return new ErrorEntityResult<CarImage>(Message.CarImageCantAdded);
            
        }


    }
}
