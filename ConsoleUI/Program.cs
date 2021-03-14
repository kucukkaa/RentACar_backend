using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            //GetAllCarsTest();
            //AddingANewCar();
            //DeleteACarTest();
            //UpdateACarTest();

            //AddANewColorTest();
            //UpdateAColorTest();
            //DeleteAColorTest();
            //GetAllColorTest();


            //AddANewBrand();
            //UpdateANewBrand();
            //DeleteABrand();

            GetAllBrandsTest();

        }

        private static void DeleteABrand()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            var brand1 = new Brand();
            brand1.BrandId = 5;

            brandManager.DeleteBrand(brand1);
        }

        private static void UpdateANewBrand()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            var brand1 = new Brand();
            brand1.BrandId = 3;
            brand1.BrandName = "BMW";

            brandManager.UpdateBrand(brand1);
        }

        private static void AddANewBrand()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var brand1 = new Brand();
            brand1.BrandName = "Hyundai";

            brandManager.AddBrand(brand1);
        }

        private static void GetAllBrandsTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            foreach (var brand in brandManager.GetBrands())
            {
                Console.WriteLine(brand.BrandId + " / " + brand.BrandName);
            }
        }

        private static void DeleteAColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            var color1 = new Color();
            color1.ColorId = 6;

            colorManager.DeleteColor(color1);
        }

        private static void UpdateAColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var color1 = new Color();
            color1.ColorId = 2;
            color1.ColorName = "Orange";

            colorManager.UpdateColor(color1);
        }

        private static void GetAllColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetColors())
            {
                Console.WriteLine(color.ColorId + "/" + color.ColorName);
            }
        }

        private static void AddANewColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            var color1 = new Color();
            color1.ColorName = "Yellow";

            colorManager.AddColor(color1);
        }

        private static void UpdateACarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var car1 = new Car();
            car1.CarId = 1;
            car1.DailyPrice = 10000;
            car1.BrandId = 1;
            car1.ColorId = 3;
            car1.Description = "nice car";
            car1.ModelYear = 2021;

            
            carManager.UpdateCar(car1);
        }

        private static void DeleteACarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var car1 = new Car();
            car1.CarId = 7;

            carManager.DeleteCar(car1);
        }

        private static void AddingANewCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var car1 = new Car();
            car1.BrandId = 3;
            car1.ColorId = 2;
            car1.DailyPrice = 500;
            car1.Description = "good car";
            car1.ModelYear = 2001;

            carManager.AddCar(car1);
        }

        private static void GetAllCarsTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.CarId + " / " + car.BrandName + " / " + car.ColorName + " / " + car.DailyPrice);
            }
        }
    }
}
