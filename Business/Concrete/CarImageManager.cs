using Business.Abstract;
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

        public IResult Update(CarImage image)
        {
            _carImageDal.Update(image);
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
                image.ImagePath = @"D:\default.jpg";
            }

            string photoExtension = Path.GetExtension(image.ImagePath);

            if (photoExtension.ToLower() == ".jpg" || photoExtension.ToLower() == ".png")
            {
                string photoName = Guid.NewGuid() + photoExtension;
                if (!Directory.Exists(@"D:\aaa\" + image.CarId))
                {
                    Directory.CreateDirectory(@"D:\aaa\" + image.CarId);
                }
                File.Copy((image.ImagePath), (@"D:\aaa\" + image.CarId + @"\" + photoName));
                image.ImagePath = @"D:\aaa\" + image.CarId + @"\" + photoName;
                image.Date = DateTime.Now;
                return new SuccessEntityResult<CarImage>(image);
            }
            return new ErrorEntityResult<CarImage>(Message.CarImageCantAdded);
            
        }
    }
}
