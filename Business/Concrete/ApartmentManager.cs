using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
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
		[SecuredOperation("admin")]
		[CacheRemoveAspect("IApartmentService.Get")]
		public IResult Add(Apartment apartment)
		{
			_apartmentDal.Add(apartment);
			return new SuccessResult(Messages.ApartmentAdded);
		}
		[SecuredOperation("admin")]
		public IResult Delete(int cardId)
		{
			_apartmentDal.Delete(_apartmentDal.Get(p => p.ApartmentId == cardId));
			return new SuccessResult(Messages.ApartmentDeleted);
		}
		[SecuredOperation("admin")]
		[CacheRemoveAspect("IApartmentService.Get")]
		public IResult Update(Apartment apartment)
		{
			_apartmentDal.Update(apartment);
			return new SuccessResult(Messages.ApartmentUpdate);
		}
		[SecuredOperation("admin")]
		[CacheAspect]
		public IDataResult<List<Apartment>> GetAll()
		{
			return new SuccessDataResult<List<Apartment>>(_apartmentDal.GetAll(), Messages.ApartmentsListed);
		}
		[SecuredOperation("admin")]
		public IDataResult<Apartment> GetById(int apartmentId)
		{
			return new SuccessDataResult<Apartment>(_apartmentDal.Get(p => p.ApartmentId == apartmentId),Messages.ApartmentViewedById);
		}
	}
}
