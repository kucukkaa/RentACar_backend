using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IColorService
    {
        List<Color> GetColors();
        void AddColor(Color color);
        void DeleteColor(Color color);
        void UpdateColor(Color color);
    }
}
