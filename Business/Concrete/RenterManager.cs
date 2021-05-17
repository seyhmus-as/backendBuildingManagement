using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
	public class RenterManager : IRenterService
	{
		IRenterDal _renterDal;
		public RenterManager(IRenterDal renterdal)
		{
			_renterDal = renterdal;
		}
		[SecuredOperation("admin")]
		[CacheRemoveAspect("IRenterService.Get")]
		//[ValidationAspect(typeof(RenterValidator))]
		public IResult Add(Renter price)
		{
			_renterDal.Add(price);
			return new SuccessResult(Messages.RenterAdded);
		}
		[SecuredOperation("admin")]
		public IResult Delete(int renterId)
		{
			_renterDal.Delete(_renterDal.Get(p => p.RenterId == renterId));
			return new SuccessResult(Messages.RenterDeleted);
		}
		[CacheRemoveAspect("IRenterService.Get")]
		[SecuredOperation("admin")]
		public IResult Update(Renter renter)
		{
			_renterDal.Update(renter);
			return new SuccessResult(Messages.RenterUpdated);
		}
		[CacheAspect]
		[SecuredOperation("admin")]
		public IDataResult<List<Renter>> GetAll()
		{
			return new SuccessDataResult<List<Renter>>(_renterDal.GetAll(), Messages.RentersListed);
		}
		[SecuredOperation("admin")]
		public IDataResult<Renter> GetById(int renterId)
		{
			return new SuccessDataResult<Renter>(_renterDal.Get(p => p.RenterId == renterId), Messages.RenterViewedById);
		}

	}
}