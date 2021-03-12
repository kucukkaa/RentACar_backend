using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {

        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{CarId = 1, BrandId = 1, ColorId = 1, ModelYear = 2020, Description = "4X4", DailyPrice = 400},
                new Car{CarId = 2, BrandId = 2, ColorId = 5, ModelYear = 2019, Description = "Diesel", DailyPrice = 250},
                new Car{CarId = 3, BrandId = 1, ColorId = 2, ModelYear = 2018, Description = "Super Lux", DailyPrice = 200},
                new Car{CarId = 4, BrandId = 3, ColorId = 3, ModelYear = 2020, Description = "For City", DailyPrice = 350},
                new Car{CarId = 5, BrandId = 4, ColorId = 2, ModelYear = 2017, Description = "Huge Car Trunk", DailyPrice = 250},
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(int Id)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }
                
        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }

        public List<Car> GetById(int Id)
        {
            //List<Car> _tempCar = new List<Car>();
            //Car carToShow = _cars.SingleOrDefault(c => c.CarId == Id);
            //_tempCar.Add(carToShow);
            //return _tempCar;

            return _cars.Where(c => c.CarId == Id).ToList();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

       

        public void Delete(Car entity)
        {
            throw new NotImplementedException();
        }
    }
}
