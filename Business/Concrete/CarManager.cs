﻿using Business.Abstract;
using Business.BusinessAspects.AutoFac;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        ICarImageService _carImageService;
        


        public CarManager(ICarDal carDal, ICarImageService carImageService)
        {
            _carDal = carDal;
            _carImageService = carImageService;           
        }

        [TransactionScopeAspect]
        [CacheRemoveAspect("ICarService.Get")]
        //[SecuredOperation("car.add, admin")]
        public IResult AddCar(Car car)
        {
            _carDal.Add(car);
            //_carImageService.AddImage(new CarImage { CarId = car.CarId });
            return new SuccessResult(Message.CarAdded);
        }

        public IResult DeleteCar(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Message.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int Id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == Id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int Id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == Id));
        }

        public IDataResult<List<Car>> GetCarsByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.DailyPrice <= max && p.DailyPrice >= min));
        }

        public IResult UpdateCar(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Message.CarUpdated);
        }

        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandId(int id)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(b => b.BrandId == id));
        }

        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarDetailsByColorId(int id)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.ColorId == id));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByColorAndBrandId(string brandName, int colorId)
        {
            var filtredByColor = _carDal.GetCarDetails(c => c.ColorId == colorId);
            return new SuccessDataResult<List<CarDetailDto>>(filtredByColor.FindAll(p => p.BrandName == brandName));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByCarId(int id)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.CarId == id));
        }
    }
}
