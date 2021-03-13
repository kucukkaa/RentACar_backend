using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities;
using System;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }

            foreach (var car in carManager.GetCarsByBrandId(2))
            {
                Console.WriteLine(car.ColorId);
            }

            foreach (var car in carManager.GetCarsByDailyPrice(200,400))
            {
                Console.WriteLine(car.DailyPrice);
            }

            ColorManager colorManager = new ColorManager(new EfColorDal());

            foreach (var color in colorManager.GetColors())
            {
                Console.WriteLine(color.ColorName);
            }

            BrandManager brandManager = new BrandManager(new EfBrandDal());

            foreach (var brand in brandManager.GetBrands())
            {
                Console.WriteLine(brand.BrandName);
            }
            
            
        }
    }
}
