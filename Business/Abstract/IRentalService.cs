﻿using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetRentals();
        IDataResult<List<RentalDetailDto>> GetRentalDetails();
        IResult AddRental(Rental rental);
        IResult DeleteRental(Rental rental);
        IResult UpdateRental(Rental rental);
        IResult RentedCarReturn(int id);

        IDataResult<List<Rental>> GetRentalsByCarId(int carId);
    }
}
