using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
	public class UserOperationClaimManager : IUserOperationClaimService
	{
		IUserOperationClaimDal _userOperationClaimDal;
		public UserOperationClaimManager(IUserOperationClaimDal userOperationClaimDal)
		{
			_userOperationClaimDal = userOperationClaimDal;
		}

		[SecuredOperation("admin")]
		public IResult Add(UserOperationClaim userOperationClaim)
		{
			_userOperationClaimDal.Add(userOperationClaim);
			return new SuccessResult(Messages.UserOperationClaimAdded);
		}

		[SecuredOperation("admin")]
		public IResult Delete(int Id)
		{
			_userOperationClaimDal.Delete(_userOperationClaimDal.Get(p => p.Id == Id));
			return new SuccessResult(Messages.UserOperationClaimDeleted);
		}

		[SecuredOperation("admin")]
		public IResult Update(UserOperationClaim userOperationClaim)
		{
			_userOperationClaimDal.Update(userOperationClaim);
			return new SuccessResult(Messages.UserOperationClaimUpdated);
		}

		[SecuredOperation("admin")]
		public IDataResult<List<UserOperationClaim>> GetAll()
		{
			return new SuccessDataResult<List<UserOperationClaim>>(_userOperationClaimDal.GetAll(), Messages.UserOperationClaimsListed);
		}
	}
}
