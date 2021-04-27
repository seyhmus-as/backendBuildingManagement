using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
	public class FlatManager : IPriceService
	{
		IPriceDal _priceDal;

		public FlatManager(IPriceDal pricedal)
		{
			_priceDal = pricedal;
		}
		public IResult Add(Price price)
		{
			_priceDal.Add(price);
			return new SuccessResult(Messages.PriceAdded);
		}
		public IResult Delete(int minuteBegin)
		{
			_priceDal.Delete(_priceDal.Get(p=>p.MinuteBegin==minuteBegin));
			return new SuccessResult(Messages.PriceDeleted);
		}
		public IResult Update(Price price)
		{
			_priceDal.Update(price);
			return new SuccessResult(Messages.PriceUpdated);
		}
		public IDataResult<List<Price>> GetAll()
		{
			return new SuccessDataResult<List<Price>>(_priceDal.GetAll(), Messages.PriceListed);
		}
		public IDataResult<Price> GetById(int MinuteBegin)
		{
			return new SuccessDataResult<Price>(_priceDal.Get(p => p.MinuteBegin == MinuteBegin));
		}

	}
}
