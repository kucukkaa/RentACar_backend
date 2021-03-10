using Business.Concrete;
using DataAccess.Concrete;
using Entities;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
             foreach (var car in carManager.GetById(1))
            {
                Console.WriteLine(car.ModelYear);
            }
            
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.CarId);
                Console.WriteLine(car.BrandId);
                Console.WriteLine(car.ColorId);
                Console.WriteLine(car.DailyPrice);
                Console.WriteLine(car.ModelYear);
                Console.WriteLine(car.Description);
            }
            carManager.Add(new Car { CarId = 6, BrandId = 3, ColorId = 2, DailyPrice = 500, Description = "for 7 People", ModelYear = 2018 });
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.CarId);
                Console.WriteLine(car.BrandId);
                Console.WriteLine(car.ColorId);
                Console.WriteLine(car.DailyPrice);
                Console.WriteLine(car.ModelYear);
                Console.WriteLine(car.Description);
            }
            carManager.Update(new Car {CarId = 2, BrandId = 5, ColorId = 1, DailyPrice = 800, Description = "Hybrid", ModelYear = 2021});
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.CarId);
                Console.WriteLine(car.BrandId);
                Console.WriteLine(car.ColorId);
                Console.WriteLine(car.DailyPrice);
                Console.WriteLine(car.ModelYear);
                Console.WriteLine(car.Description);
            }
            carManager.Delete(3);
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.CarId);
                Console.WriteLine(car.BrandId);
                Console.WriteLine(car.ColorId);
                Console.WriteLine(car.DailyPrice);
                Console.WriteLine(car.ModelYear);
                Console.WriteLine(car.Description);
            }
        }
    }
}
