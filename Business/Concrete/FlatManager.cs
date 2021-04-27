using Business.Abstract;
using Business.Constants;
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
		public IResult Add(Flat flat)
		{
			_flatDal.Add(flat);
			return new SuccessResult(Messages.PriceAdded);
		}
		public IResult Delete(int flatId)
		{
			_flatDal.Delete(_flatDal.Get(p => p.FlatId == flatId));
			return new SuccessResult(Messages.FlatDeleted);
		}
		public IResult Update(Flat flat)
		{
			_flatDal.Update(flat);
			return new SuccessResult(Messages.PriceUpdated);
		}
		public IDataResult<List<Flat>> GetAll()
		{
			return new SuccessDataResult<List<Flat>>(_flatDal.GetAll(), Messages.PriceListed);
		}
		public IDataResult<Flat> GetById(int flatId)
		{
			return new SuccessDataResult<Flat>(_flatDal.Get(p => p.FlatId == flatId));
		}

		public IDataResult<List<FlatDetailDto>> GetFlatDetails()
		{
			return new SuccessDataResult<List<FlatDetailDto>>(_flatDal.GetFlatDetails());
		}


	}
}
