using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarDbContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (RentACarDbContext context = new RentACarDbContext())
            {
                var result = from r in context.Rentals join c in context.Cars on r.CarId equals c.CarId join b in context.Brands on c.BrandId equals b.BrandId join cus in context.Customers on r.CustomerId equals cus.CustomerId join col in context.Colors on c.ColorId equals col.ColorId select new RentalDetailDto { RentalId = r.RentalId, CarId = c.CarId, BrandName = b.BrandName, ColorName = col.ColorName, CustomerName = cus.CompanyName, RentDate = r.RentDate, ReturnDate = r.ReturnDate };
                return result.ToList();
            }
        }
    }
}
