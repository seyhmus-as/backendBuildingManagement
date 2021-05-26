using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Business.Concrete
{
	public class CardHistoryManager : ICardHistoryService
	{
		ICardHistoryDal _cardHistoryDal;

		public CardHistoryManager(ICardHistoryDal parkHistorydal)
		{
			_cardHistoryDal = parkHistorydal;
		}

		[ValidationAspect(typeof(CardHistoryValidator))]
		[LogAspect(typeof(FileLogger))]
		[LogAspect(typeof(DatabaseLogger))]
		[SecuredOperation("admin")]
		[CacheRemoveAspect("ICardHistoryService.Get")]
		public IResult Add(CardHistory cardHistorydal)
		{
			_cardHistoryDal.Add(cardHistorydal);
			return new SuccessResult(Messages.CardHistoryAdded);
		}

		[SecuredOperation("admin")]
		[CacheRemoveAspect("ICardHistoryService.Get")]
		public IResult Delete(int id)
		{
			_cardHistoryDal.Delete(_cardHistoryDal.Get(p => p.Id == id));
			return new SuccessResult(Messages.CardHistoryDeleted);
		}

		[SecuredOperation("admin")]
		[CacheRemoveAspect("ICardHistoryService.Get")]
		[ValidationAspect(typeof(CardHistoryValidator))]
		public IResult Update(CardHistory cardHistory)
		{
			_cardHistoryDal.Update(cardHistory);
			return new SuccessResult(Messages.CardHistoryUpdate);
		}

		[SecuredOperation("admin,personnel")]
		[CacheAspect(duration: 10)]
		[TransactionScopeAspect]
		[PerformanceAspect(5)]
		public IDataResult<List<CardHistory>> GetAll()
		{
			return new SuccessDataResult<List<CardHistory>>(_cardHistoryDal.GetAll(), Messages.CardHistoriesListed);
		}

		[SecuredOperation("admin,personnel")]
		public IDataResult<List<CardHistory>> GetById(int cardId)
		{
			return new SuccessDataResult<List<CardHistory>>(_cardHistoryDal.GetAll(p => p.CardId == cardId), Messages.CardHistoryViewedById);
		}

		[SecuredOperation("admin,personnel")]
		public IDataResult<List<CardHistoryDetailDto>> GetMonthlyMoneyById(int flatId, int secondBegin, int secondFinal, bool isIncome)
		{
			var processesBetweenInterval = _cardHistoryDal.GetCardHistoryDetails();

			processesBetweenInterval = processesBetweenInterval.FindAll(p =>
						 (p.Date.Value.Second >= secondBegin && p.Date.Value.Second <= secondFinal) &&
						 (p.FlatId == flatId) &&
						 (p.IsIncome == isIncome)
				   );
			return new SuccessDataResult<List<CardHistoryDetailDto>>(processesBetweenInterval, Messages.CardHistoryMonthlyMoneyListed);
		}

		[SecuredOperation("admin,personnel")]
		public IDataResult<int> GetMonthlyMoneyTotalById(int flatId, int secondBegin, int secondFinal, bool isIncome)
		{
			var processesBetweenInterval = _cardHistoryDal.GetCardHistoryDetails().FindAll(p =>
					   (p.Date.Value.Second >= secondBegin && p.Date.Value.Second <= secondFinal) &&
					   (p.FlatId == flatId) &&
					   (p.IsIncome == isIncome)
				   );
			int total = 0;
			for (int i = 0; i < processesBetweenInterval.Count; i++)
			{
				total += processesBetweenInterval[i].Price;
			}
			return new SuccessDataResult<int>(total, Messages.CardHistoryMonthlyMoneyTotalViewedById);
		}

		[SecuredOperation("admin")]
		public IDataResult<int> GetMonthlyMoney(int secondBegin, int secondFinal, bool isIncome)
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
			return new SuccessDataResult<int>(total, Messages.CardHistoryMonthlyMoneyTotalViewed);
		}

		[SecuredOperation("admin,personnel")]
		public IDataResult<List<CardHistoryDetailDto>> GetCardHistoryDetails()
		{
			return new SuccessDataResult<List<CardHistoryDetailDto>>(_cardHistoryDal.GetCardHistoryDetails());
		}
	}
}
