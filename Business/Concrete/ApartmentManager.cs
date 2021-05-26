using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{

	public class ApartmentManager : IApartmentService
	{
		IApartmentDal _apartmentDal;
		public ApartmentManager(IApartmentDal apartmentDal)
		{
			_apartmentDal = apartmentDal;
		}

		[ValidationAspect(typeof(ApartmentValidator))]
		[SecuredOperation("admin,personnel")]
		[CacheRemoveAspect("IApartmentService.Get")]
		public IResult Add(Apartment apartment)
		{
			_apartmentDal.Add(apartment);
			return new SuccessResult(Messages.ApartmentAdded);
		}

		[SecuredOperation("admin,personnel")]
		[CacheRemoveAspect("IApartmentService.Get")]
		public IResult Delete(int cardId)
		{
			_apartmentDal.Delete(_apartmentDal.Get(p => p.ApartmentId == cardId));
			return new SuccessResult(Messages.ApartmentDeleted);
		}

		[SecuredOperation("admin,personnel")]
		[CacheRemoveAspect("IApartmentService.Get")]
		[ValidationAspect(typeof(ApartmentValidator))]
		public IResult Update(Apartment apartment)
		{
			_apartmentDal.Update(apartment);
			return new SuccessResult(Messages.ApartmentUpdate);
		}

		[SecuredOperation("admin,personnel")]
		[CacheAspect(duration: 10)]
		[TransactionScopeAspect]
		[PerformanceAspect(5)]
		public IDataResult<List<Apartment>> GetAll()
		{
			return new SuccessDataResult<List<Apartment>>(_apartmentDal.GetAll(), Messages.ApartmentsListed);
		}

		[SecuredOperation("admin,personnel")]
		public IDataResult<Apartment> GetById(int apartmentId)
		{
			return new SuccessDataResult<Apartment>(_apartmentDal.Get(p => p.ApartmentId == apartmentId),Messages.ApartmentViewedById);
		}
	}
}
