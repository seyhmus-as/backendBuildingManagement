using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Entities.Concrete;
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
        [SecuredOperation("admin")]
        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }
        [SecuredOperation("admin")]
        public void Add(User user)
        {
            _userDal.Add(user);
        }
        [SecuredOperation("admin")]
        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }
    }
}