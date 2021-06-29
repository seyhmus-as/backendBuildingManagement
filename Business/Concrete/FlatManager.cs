using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
	public class FlatManager : IFlatService
	{
		IFlatDal _flatDal;
		public FlatManager(IFlatDal flatdal)
		{
			_flatDal = flatdal;
		}

		[ValidationAspect(typeof(FlatValidator))]
		[SecuredOperation("admin,personnel")]
		[CacheRemoveAspect("IFlatService.Get")]
		[LogAspect(typeof(FileLogger))]
		[LogAspect(typeof(DatabaseLogger))]
		public IResult Add(Flat flat)
		{
			_flatDal.Add(flat);
			return new SuccessResult(Messages.FlatAdded);
		}

		[SecuredOperation("admin,personnel")]
		[CacheRemoveAspect("IFlatService.Get")]
		public IResult Delete(int id)
		{
			_flatDal.Delete(_flatDal.Get(p => p.Id == id));
			return new SuccessResult(Messages.FlatDeleted);
		}

		[CacheRemoveAspect("IFlatService.Get")]
		[ValidationAspect(typeof(FlatValidator))]
		[SecuredOperation("admin,personnel")]
		public IResult Update(Flat flat)
		{
			_flatDal.Update(flat);
			return new SuccessResult(Messages.FlatUpdated);
		}

		[CacheAspect(duration: 10)]
		[SecuredOperation("admin,personnel")]
		public IDataResult<List<Flat>> GetAll()
		{
			return new SuccessDataResult<List<Flat>>(_flatDal.GetAll(), Messages.FlatsListed);
		}

		[SecuredOperation("admin,personnel")]
		public IDataResult<List<Flat>> GetById(int flatId)
		{
			return new SuccessDataResult<List<Flat>> (_flatDal.GetAll(p => p.Id == flatId), Messages.FlatViewedById);
		}

		[CacheAspect]
		[SecuredOperation("admin,personnel")]
		public IDataResult<List<FlatDetailDto>> GetFlatDetails()
		{
			return new SuccessDataResult<List<FlatDetailDto>>(_flatDal.GetFlatDetails());
		}


	}
}
