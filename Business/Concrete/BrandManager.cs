using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using DataAccess.Abstract;
using System.Text;
using Core.Utilities.Results;
using Business.Constants;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {

        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult AddBrand(Brand brand)
        {

            if (brand.BrandName.Length > 2)
            {
                _brandDal.Add(brand);
                return new SuccessResult(Message.BrandAdded);
            }
            else
            {
                return new ErrorResult(Message.BrandNameInvalid);
            }
            
        }

        public IResult DeleteBrand(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Message.BrandDeleted);
        }

        public IDataResult<List<Brand>> GetBrands()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
        }

        public IResult UpdateBrand(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult(Message.BrandUpdated);
        }
    }
}
