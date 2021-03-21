using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorEntityResult<T> : EntityResult<T>
    {
        public ErrorEntityResult(T entity, string message) : base(entity, true, message)
        {

        }

        public ErrorEntityResult(T entity) : base(entity, true)
        {

        }

        public ErrorEntityResult(string message) : base(default, true, message)
        {

        }

        public ErrorEntityResult() : base(default, true)
        {

        }
    }
}
