﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBrandService
    {
        List<Brand> GetBrands();
        void AddBrand(Brand brand);
        void DeleteBrand(Brand brand);
        void UpdateBrand(Brand brand);

    }
}
