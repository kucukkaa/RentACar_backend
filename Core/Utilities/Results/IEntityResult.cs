using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public interface IEntityResult<T> : IResult
    {
        T Entity { get; }
    }
}
