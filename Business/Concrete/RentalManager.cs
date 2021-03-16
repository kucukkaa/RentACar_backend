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
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;


        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public IResult AddRental(Rental rental)
        {
            var addable = true;

            foreach (var rentalItem in _rentalDal.GetAll())
            {
                if (rentalItem.CarId == rental.CarId && rentalItem.ReturnDate == null)
                {
                    addable = false;
                    break;
                }
            }

            if(addable)
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Message.RentalAdded);
            }
            else
            {
                return new ErrorResult(Message.CarUnavailable);
            }

        }

        public IResult DeleteRental(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Message.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetRentals()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IResult RentedCarReturn(int id)
        {
            foreach (var rentalItem in _rentalDal.GetAll())
            {
                if (rentalItem.CarId == id && rentalItem.ReturnDate == null)
                {
                    rentalItem.ReturnDate = DateTime.Now;
                    return new SuccessResult(Message.CarReturn);
                }
            }
            
            return new ErrorResult(Message.CarReturnError);
        }

        public IResult UpdateRental(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Message.RentalUpdated);
        }
    }
}
