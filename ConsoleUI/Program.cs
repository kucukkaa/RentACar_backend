using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities;
using Entities.Concrete;
using System;
using System.Data.SqlTypes;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            //AddANewColorTest();
            //UpdateAColorTest();
            //DeleteAColorTest();
            //GetAllColorTest();

            //AddANewBrand();
            //UpdateABrand();
            //DeleteABrand();
            //GetAllBrandsTest();

            //GetAllCarsTest();
            //AddingANewCar();
            //DeleteACarTest();
            //UpdateACarTest();

            //AddNewRental();
            //RentalList();

            //CarReturn();


            AddCarImageTest();
        }

        private static void AddCarImageTest()
        {
            CarImagesManager carImagesManager = new CarImagesManager(new EfCarImageDal());
            var carImage1 = new CarImage();
            carImage1.CarId = 2;
            carImage1.Date = DateTime.Now;
            carImage1.ImagePath = @"D:\aa\WhatsApp Images\IMG-20201209-WA0012.jpg";

            carImagesManager.AddImage(carImage1);
        }

        private static void CarReturn()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            var result = rentalManager.RentedCarReturn(7);

            Console.WriteLine(result.Message);
        }

        private static void RentalList()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            var result = rentalManager.GetRentalDetails();

            foreach (var item in result.Data)
            {
                Console.WriteLine(item.RentalId + " / " + item.CarId + " / " + item.CustomerName + " / " + item.RentDate + " / " + item.ReturnDate + " / " + item.BrandName + " / " + item.ColorName);
            }
        }

        private static void AddNewRental()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            var rental1 = new Rental();
            rental1.CarId = 7;
            rental1.CustomerId = 7;
            rental1.RentDate = DateTime.Now;



            var result = rentalManager.AddRental(rental1);

            Console.WriteLine(result.Message);
        }

        private static void DeleteABrand()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            var brand1 = new Brand();
            brand1.BrandId = 3;

            brandManager.DeleteBrand(brand1);
        }

        private static void UpdateABrand()
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
            brand1.BrandName = "Renault";

            brandManager.AddBrand(brand1);
        }

        private static void GetAllBrandsTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result = brandManager.GetBrands();

            if (result.Success)
            {
                foreach (var brand in result.Data)
                {
                    Console.WriteLine(brand.BrandId + " / " + brand.BrandName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
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
            var result = colorManager.GetColors();

            if (result.Success)
            {
                foreach (var color in result.Data)
                {
                    Console.WriteLine(color.ColorId + "/" + color.ColorName);
                }
                Console.WriteLine(result.Message); //listleme işlemine eklenen mesaj
            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }

        private static void AddANewColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            var color1 = new Color();
            color1.ColorName = "White";

            var result = colorManager.AddColor(color1); //addcolor işleminin ilettiği mesajı görmek için
            Console.WriteLine(result.Message);
        }

        private static void UpdateACarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var car1 = new Car();
            car1.CarId = 1;
            car1.DailyPrice = 200;
            car1.BrandId = 1;
            car1.ColorId = 1;
            car1.Description = "nice car";
            car1.ModelYear = 2021;


            carManager.UpdateCar(car1);
        }

        private static void DeleteACarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var car1 = new Car();
            car1.CarId = 2;

            carManager.DeleteCar(car1);
        }

        private static void AddingANewCarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var car1 = new Car();
            car1.BrandId = 3;
            car1.ColorId = 2;
            car1.DailyPrice = 7000;
            car1.Description = "good car";
            car1.ModelYear = 2001;

            carManager.AddCar(car1);
        }

        private static void GetAllCarsTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetails();

            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarId + " / " + car.BrandName + " / " + car.ColorName + " / " + car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }


        }
    }
}
