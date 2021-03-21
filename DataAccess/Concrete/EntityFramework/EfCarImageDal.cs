using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarImageDal : EfEntityRepositoryBase<CarImage, RentACarDbContext>, ICarImageDal
    {
        public override void Add(CarImage image)
        {
            string photoExtension = Path.GetExtension(image.ImagePath);

            if (photoExtension.ToLower() == ".jpg" || photoExtension.ToLower() == ".png")
            {
                string photoName = Guid.NewGuid() + photoExtension;
                File.Copy((image.ImagePath),(@"D:\aa\aas\" + photoName));
                image.ImagePath = @"D:\aa\aas\" + photoName;
                base.Add(image);
            }
            else
            {
                Console.WriteLine("resim eklenemedi");
            }
            
        }
    }
}

