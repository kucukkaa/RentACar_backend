using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using DataAccess.Abstract;
using System.Text;

namespace Business.Concrete
{
    class BrandManager : IBrandService
    {

        IBrandDal _brandDal;
        public List<Brand> GetBrands()
        {
            throw new NotImplementedException();
        }
    }
}
