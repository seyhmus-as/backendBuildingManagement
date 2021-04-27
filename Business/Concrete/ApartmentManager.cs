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
		//[SecuredOperation("personnel,admin")]
		//[CacheAspect]
		IApartmentDal _apartmentDal;
		public ApartmentManager(IApartmentDal apartmentDal)
		{
			_apartmentDal = apartmentDal;
		}
		public IResult Add(Apartment apartment)
		{
			_apartmentDal.Add(apartment);
			return new SuccessResult(Messages.CarAdded);
		}
		public IResult Delete(int carId)
		{
			_apartmentDal.Delete(_apartmentDal.Get(p => p.ApartmentId == carId));
			return new SuccessResult(Messages.CarDeleted);
		}
		public IResult Update(Apartment apartment)
		{
			_apartmentDal.Update(apartment);
			return new SuccessResult(Messages.CarUpdate);
		}
		public IDataResult<List<Apartment>> GetAll()
		{
			return new SuccessDataResult<List<Apartment>>(_apartmentDal.GetAll(), Messages.CarsListed);
		}
		public IDataResult<Apartment> GetById(int apartmentId)
		{
			return new SuccessDataResult<Apartment>(_apartmentDal.Get(p => p.ApartmentId == apartmentId));
		}
	}
}
