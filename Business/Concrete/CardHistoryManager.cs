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
	public class CardHistoryManager : ICardHistoryService
	{
		ICardHistoryDal _cardHistoryDal;

		public CardHistoryManager(ICardHistoryDal parkHistorydal)
		{
			_cardHistoryDal = parkHistorydal;
		}
		public IResult Add(CardHistory cardHistorydal)
		{
			_cardHistoryDal.Add(cardHistorydal);
			return new SuccessResult(Messages.ParkHistoryAdded);
		}
		public IResult Delete(int id)
		{
			_cardHistoryDal.Delete(_cardHistoryDal.Get(p => p.Id == id));
			return new SuccessResult(Messages.cardHistoryDeleted);
		}
		public IResult Update(CardHistory cardHistory)
		{
			_cardHistoryDal.Update(cardHistory);
			return new SuccessResult(Messages.parkHistoryUpdate);
		}
		public IDataResult<List<CardHistory>> GetAll()
		{
			return new SuccessDataResult<List<CardHistory>>(_cardHistoryDal.GetAll(), Messages.ParkHistoryListed);
		}
		public IDataResult<List<CardHistory>> GetById(int carId)
		{
			return new SuccessDataResult<List<CardHistory>>(_cardHistoryDal.GetAll(p => p.CardId == carId));
		}
	}
}
