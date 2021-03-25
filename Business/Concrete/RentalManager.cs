using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;


        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [PerformanceAspect(5)]
        [TransactionScopeAspect]
        [CacheRemoveAspect("IRentalService.Get")]
        [ValidationAspect(typeof(RentalValidator))]
        public IResult AddRental(Rental rental)
        {
            IResult result = BusinessRules.Run(IsCarAvaibleForRent(rental.CarId));

            if (result != null)
            {
                return result;
            }

            _rentalDal.Add(rental);
            return new SuccessResult(Message.RentalAdded);
        }

        

        [CacheRemoveAspect("IRentalService.Get")]
        public IResult DeleteRental(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Message.RentalDeleted);
        }

        [CacheAspect]
        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }

        [CacheAspect]
        public IDataResult<List<Rental>> GetRentals()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        [CacheRemoveAspect("IRentalService.Get")]
        public IResult RentedCarReturn(int id)
        {
            foreach (var rentalItem in _rentalDal.GetAll())
            {
                if (rentalItem.CarId == id && rentalItem.ReturnDate == null)
                {
                    rentalItem.ReturnDate = DateTime.Now;
                    UpdateRental(rentalItem);
                    return new SuccessResult(Message.CarReturn);
                }
            }

            return new ErrorResult(Message.CarReturnError);
        }
        
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult UpdateRental(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Message.RentalUpdated);
        }

        private IResult IsCarAvaibleForRent(int carId)
        {
            foreach (var rentalItem in _rentalDal.GetAll())
            {
                if (rentalItem.CarId == carId && rentalItem.ReturnDate == null)
                {
                    return new ErrorResult(Message.CarUnavailable);
                }
            }
            return new SuccessResult();
        }

    }
}
