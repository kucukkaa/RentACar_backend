using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal
    {
        List<Car> GetById(int Id);
        List<Car> GetAll();
        void Add(Car car);
        void Update(Car car);
        void Delete(int Id);
    }
}
