using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        void Add(Car car);
        void Delete(int Id);
        List<Car> GetById(int Id);
        void Update(Car car);

    }
}
