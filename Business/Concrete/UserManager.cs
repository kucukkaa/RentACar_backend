using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        public IResult AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public IResult DeleteUser(User user)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<User>> GetUsers()
        {
            throw new NotImplementedException();
        }

        public IResult UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
