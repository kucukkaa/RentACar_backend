﻿using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult AddImage(IFormFile file, CarImage image);
        IDataResult<List<CarImage>>GetCarImages();
        IResult Update(CarImage image);
        IResult Delete(CarImage image);
        IDataResult<List<CarImage>> GetImagesOfACar(int id);
    }
}
