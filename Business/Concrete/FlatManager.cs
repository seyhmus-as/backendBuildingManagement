using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
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
		[SecuredOperation("admin")]
		[CacheRemoveAspect("IFlatService.Get")]
		[LogAspect(typeof(FileLogger))]
		[LogAspect(typeof(DatabaseLogger))]
		public IResult Add(Flat flat)
		{
			_flatDal.Add(flat);
			return new SuccessResult(Messages.FlatAdded);
		}
		[SecuredOperation("admin")]
		public IResult Delete(int flatId)
		{
			_flatDal.Delete(_flatDal.Get(p => p.FlatId == flatId));
			return new SuccessResult(Messages.FlatDeleted);
		}
		[CacheRemoveAspect("IFlatService.Get")]
		[SecuredOperation("admin")]
		public IResult Update(Flat flat)
		{
			_flatDal.Update(flat);
			return new SuccessResult(Messages.FlatUpdated);
		}
		[CacheAspect]
		[SecuredOperation("admin")]
		public IDataResult<List<Flat>> GetAll()
		{
			return new SuccessDataResult<List<Flat>>(_flatDal.GetAll(), Messages.FlatsListed);
		}
		[SecuredOperation("admin")]
		public IDataResult<Flat> GetById(int flatId)
		{
			return new SuccessDataResult<Flat>(_flatDal.Get(p => p.FlatId == flatId), Messages.FlatViewedById);
		}
		[CacheAspect]
		[SecuredOperation("admin")]
		public IDataResult<List<FlatDetailDto>> GetFlatDetails()
		{
			return new SuccessDataResult<List<FlatDetailDto>>(_flatDal.GetFlatDetails());
		}


	}
}
