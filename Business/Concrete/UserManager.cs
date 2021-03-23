using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    { 
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;

        }
        public IResult AddUser(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Message.UserAdded);
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

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.UserEMail == email);
        }
    }
}
