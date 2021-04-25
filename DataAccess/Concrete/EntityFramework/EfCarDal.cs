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
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarDbContext>, ICarDal
    {
        //public List<CarDetailDto> GetCarDetails()
        //{
        //    using (RentACarDbContext context = new RentACarDbContext())
        //    {
        //        var result = from c in context.Cars 
        //                     join col in context.Colors on c.ColorId equals col.ColorId 
        //                     join b in context.Brands on c.BrandId equals b.BrandId
        //                     select new CarDetailDto { 
        //                         CarId = c.CarId, 
        //                         BrandName = b.BrandName, 
        //                         ColorName = col.ColorName, 
        //                         DailyPrice = c.DailyPrice
        //                     };
        //        return result.ToList();
        //    }
        //}

        //public List<CarDetailDto> GetCarDetailsByBrandId(int id)
        //{
        //    using (RentACarDbContext context = new RentACarDbContext())
        //    {
        //        var result = from c in context.Cars 
        //                     join col in context.Colors on c.ColorId equals col.ColorId 
        //                     join b in context.Brands on c.BrandId equals b.BrandId
        //                     where c.BrandId == id 
        //                     select new CarDetailDto { 
        //                         CarId = c.CarId, 
        //                         BrandName = b.BrandName, 
        //                         ColorName = col.ColorName, 
        //                         DailyPrice = c.DailyPrice
        //                     };
        //        return result.ToList();
        //    }
        //}

        //public List<CarDetailDto> GetCarDetailsByColorId(int id)
        //{
        //    using (RentACarDbContext context = new RentACarDbContext())
        //    {
        //        var result = from c in context.Cars 
        //                     join col in context.Colors on c.ColorId equals col.ColorId 
        //                     join b in context.Brands on c.BrandId equals b.BrandId
        //                     where c.ColorId == id 
        //                     select new CarDetailDto { 
        //                         CarId = c.CarId, 
        //                         BrandName = b.BrandName, 
        //                         ColorName = col.ColorName, 
        //                         DailyPrice = c.DailyPrice
        //                     };
        //        return result.ToList();
        //    }
        //}

        //public List<CarDetailDto> GetCarDetailsByCarId(int id)
        //{
        //    using (RentACarDbContext context = new RentACarDbContext())
        //    {
        //        var result = from c in context.Cars 
        //                     join col in context.Colors on c.ColorId equals col.ColorId 
        //                     join b in context.Brands on c.BrandId equals b.BrandId
        //                     where c.CarId == id select new CarDetailDto { 
        //                         CarId = c.CarId,
        //                         BrandName = b.BrandName,
        //                         ColorName = col.ColorName, 
        //                         DailyPrice = c.DailyPrice,
        //                     };
        //        return result.ToList();
        //    }
        //}

        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (RentACarDbContext context = new RentACarDbContext())
            {
                var result = from c in filter == null ? context.Cars : context.Cars.Where(filter)
                             join col in context.Colors on c.ColorId equals col.ColorId
                             join b in context.Brands on c.BrandId equals b.BrandId
                             let image=(from carImage in context.CarImages where c.CarId==carImage.CarId select carImage.ImagePath)
                             select new CarDetailDto
                             {
                                 CarId = c.CarId,
                                 BrandName = b.BrandName,
                                 ColorName = col.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 ImagePath = image.Any()?image.FirstOrDefault(): new CarImage {ImagePath =@"/images/default.png"}.ImagePath
                             };
                return result.ToList();
            }
        }
    }
}
