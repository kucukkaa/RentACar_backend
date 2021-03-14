using Entities;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        List<Car> GetCarsByBrandId(int Id);
        List<Car> GetCarsByDailyPrice(decimal min, decimal max);
        List<Car> GetCarsByColorId(int Id);

        List<CarDetailDto> GetCarDetails();

        void AddCar(Car car);
        void DeleteCar(Car car);
        void UpdateCar(Car car);
    }
}
