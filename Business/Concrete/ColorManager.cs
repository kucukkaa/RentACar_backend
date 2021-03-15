using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {

        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult AddColor(Color color)
        {
            _colorDal.Add(color);
            return new SuccessResult(Message.ColorAdded);
        }

        public IResult DeleteColor(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(Message.ColorDeleted);
        }

        public IDataResult<List<Color>> GetColors()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(),Message.AllColors);
        }

        public IResult UpdateColor(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult(Message.ColorUpdated);
        }
    }
}
