using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Core.DataAccess.EntityFramework;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarDbContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RentACarDbContext context = new RentACarDbContext())
            {
                var result = from c in context.Cars join col in context.Colors on c.ColorId equals col.ColorId join b in context.Brands on c.BrandId equals b.BrandId join pic in context.CarImages on c.CarId equals pic.CarId select new CarDetailDto { CarId = c.CarId, BrandName = b.BrandName, ColorName = col.ColorName, DailyPrice = c.DailyPrice, ImagePath = pic.ImagePath };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailsByBrandId(int id)
        {
            using (RentACarDbContext context = new RentACarDbContext())//sgdthfj
            {
                var result = from c in context.Cars join col in context.Colors on c.ColorId equals col.ColorId join b in context.Brands on c.BrandId equals b.BrandId where c.CarId == id select new CarDetailDto { CarId = c.CarId, BrandName = b.BrandName, ColorName = col.ColorName, DailyPrice = c.DailyPrice };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailsByColorId(int id)
        {
            using (RentACarDbContext context = new RentACarDbContext())//sgdthfj
            {
                var result = from c in context.Cars join col in context.Colors on c.ColorId equals col.ColorId join b in context.Brands on c.BrandId equals b.BrandId where c.ColorId == id select new CarDetailDto { CarId = c.CarId, BrandName = b.BrandName, ColorName = col.ColorName, DailyPrice = c.DailyPrice };
                return result.ToList();
            }
        }
    }
}
