using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessEntityResult<T> : EntityResult<T>
    {
        public SuccessEntityResult(T entity, string message) : base(entity, true, message)
        {

        }

        public SuccessEntityResult(T entity) : base(entity, true)
        {

        }

        public SuccessEntityResult(string message) : base(default, true, message)
        {

        }

        public SuccessEntityResult() : base(default, true)
        {

        }
    }
}
