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
		[SecuredOperation("admin")]
		[CacheRemoveAspect("ICardHistoryService.Get")]
		public IResult Add(CardHistory cardHistorydal)
		{
			_cardHistoryDal.Add(cardHistorydal);
			return new SuccessResult(Messages.ParkHistoryAdded);
		}
		[SecuredOperation("admin")]
		public IResult Delete(int id)
		{
			_cardHistoryDal.Delete(_cardHistoryDal.Get(p => p.Id == id));
			return new SuccessResult(Messages.cardHistoryDeleted);
		}
		[SecuredOperation("admin")]
		[CacheRemoveAspect("ICardHistoryService.Get")]
		public IResult Update(CardHistory cardHistory)
		{
			_cardHistoryDal.Update(cardHistory);
			return new SuccessResult(Messages.parkHistoryUpdate);
		}
		[SecuredOperation("admin")]
		[CacheAspect]
		public IDataResult<List<CardHistory>> GetAll()
		{
			return new SuccessDataResult<List<CardHistory>>(_cardHistoryDal.GetAll(), Messages.ParkHistoryListed);
		}
		[SecuredOperation("admin")]
		public IDataResult<List<CardHistory>> GetById(int cardId)
		{
			return new SuccessDataResult<List<CardHistory>>(_cardHistoryDal.GetAll(p => p.CardId == cardId));
		}
		[SecuredOperation("admin")]
		public IDataResult<List<CardHistoryDetailDto>> GetMonthMoneyById(int flatId, int secondBegin, int secondFinal, bool isIncome)
		{
			var processesBetweenInterval = _cardHistoryDal.GetCardHistoryDetails().FindAll(p =>
					   (p.Date.Value.Second > secondBegin && p.Date.Value.Second < secondFinal) &&
					   (p.FlatId == flatId) &&
					   (p.IsIncome = isIncome)
				   );
			return new SuccessDataResult<List<CardHistoryDetailDto>>(processesBetweenInterval);
		}
		[SecuredOperation("admin")]
		public IDataResult<int> GetMonthMoneyTotalById(int flatId, int secondBegin, int secondFinal, bool isIncome)
		{
			var processesBetweenInterval = _cardHistoryDal.GetCardHistoryDetails().FindAll(p =>
					   (p.Date.Value.Second > secondBegin && p.Date.Value.Second < secondFinal) &&
					   (p.FlatId == flatId) &&
					   (p.IsIncome = isIncome)
				   );
			int total = 0;
			for (int i = 0; i < processesBetweenInterval.Count; i++)
			{
				total += processesBetweenInterval[i].Price;
			}
			return new SuccessDataResult<int>(total);
		}
		[CacheAspect]
		[SecuredOperation("admin")]
		public IDataResult<int> GetMonthMoney(int secondBegin, int secondFinal, bool isIncome)
		{
			var processesBetweenInterval = _cardHistoryDal.GetCardHistoryDetails().FindAll(p =>
					   (p.Date.Value.Second > secondBegin && p.Date.Value.Second < secondFinal) &&
					   (p.IsIncome == isIncome)
				   );
			int total = 0;
			for (int i = 0; i < processesBetweenInterval.Count; i++)
			{
				total += processesBetweenInterval[i].Price;
			}
			return new SuccessDataResult<int>(total);
		}
		[SecuredOperation("admin")]
		public IDataResult<List<CardHistoryDetailDto>> GetCardHistoryDetails()
		{
			return new SuccessDataResult<List<CardHistoryDetailDto>>(_cardHistoryDal.GetCardHistoryDetails());
		}
	}
}
