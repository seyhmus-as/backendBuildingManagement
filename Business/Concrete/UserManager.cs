using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{

	public class UserManager : IUserService
	{
		IUserDal _userDal;
		IUserOperationClaimDal _userOperationDal;

		public UserManager(IUserDal userDal,IUserOperationClaimDal userOperationClaimDal)
		{
			_userDal = userDal;
			_userOperationDal = userOperationClaimDal;
		}

		public List<OperationClaim> GetClaims(User user)
		{
			return _userDal.GetClaims(user);
		}

		public void Add(User user)
		{
			_userDal.Add(user);
		}

		public User GetByMail(string email)
		{
			return _userDal.Get(u => u.Email == email);
		}

		[SecuredOperation("admin")]
		public IResult Delete(string email)
		{
			_userDal.Delete(_userDal.Get(p => p.Email == email));
			return new SuccessResult(Messages.UserDeleted);
		}

		[SecuredOperation("admin")]
		public IDataResult<List<UserDetailDto>> GetUserDetails()
		{
			return new SuccessDataResult<List<UserDetailDto>>(_userDal.GetUserDetails(), Messages.UsersListed);
		}

		[SecuredOperation("admin")]
		public IDataResult<List<UserForShowingDto>> GetUserAll()
		{
			return new SuccessDataResult<List<UserForShowingDto>>(_userDal.GetUserAll(), Messages.UsersListed);
		}
	}
}