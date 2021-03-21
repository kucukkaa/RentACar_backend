using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class EntityResult<T> : Result, IEntityResult<T>
    {
        public EntityResult(T entity, bool success, string message) : base(success, message)
        {
            Entity = entity;
        }

        public EntityResult(T entity, bool success) : base(success)
        {
            Entity = entity;
        }


        public T Entity { get; }
    }
}
