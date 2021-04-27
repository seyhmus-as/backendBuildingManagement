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
	public class RenterManager : IRenterService
	{
		IRenterDal _renterDal;

		public RenterManager(IRenterDal renterdal)
		{
			_renterDal = renterdal;
		}
		public IResult Add(Renter price)
		{
			_renterDal.Add(price);
			return new SuccessResult(Messages.PriceAdded);
		}
		public IResult Delete(int renterId)
		{
			_renterDal.Delete(_renterDal.Get(p => p.RenterId == renterId));
			return new SuccessResult(Messages.PriceDeleted);
		}
		public IResult Update(Renter renter)
		{
			_renterDal.Update(renter);
			return new SuccessResult(Messages.PriceUpdated);
		}
		public IDataResult<List<Renter>> GetAll()
		{
			return new SuccessDataResult<List<Renter>>(_renterDal.GetAll(), Messages.RenterListed);
		}
		public IDataResult<Renter> GetById(int renterId)
		{
			return new SuccessDataResult<Renter>(_renterDal.Get(p => p.RenterId == renterId));
		}

	}
}
