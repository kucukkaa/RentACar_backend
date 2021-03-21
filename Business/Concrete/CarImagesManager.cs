using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarImagesManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImagesManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }
        
        
        public IResult AddImage(CarImage image)
        {
            _carImageDal.Add(image);
            return new SuccessResult(Message.CarImageAdded);
        }
    }
}
