﻿using Core.DataAccess;
using Entities;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarDetails(Expression <Func<Car, bool>> filter = null);
        //List<CarDetailDto> GetCarDetailsByBrandId(int id);
        //List<CarDetailDto> GetCarDetailsByColorId(int id);
        //List<CarDetailDto> GetCarDetailsByCarId(int id);
    }
}
