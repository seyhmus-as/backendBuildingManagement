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
	public class CardManager : ICardService
	{
		ICardDal _cardDal;
		public CardManager(ICardDal cardDal)
		{
			_cardDal = cardDal;
		}

		[ValidationAspect(typeof(CardValidator))]
		[LogAspect(typeof(FileLogger))]
		[LogAspect(typeof(DatabaseLogger))]
		[SecuredOperation("admin,personnel")]
		[CacheRemoveAspect("ICardService.Get")]
		public IResult Add(Card card)
		{
			_cardDal.Add(card);
			return new SuccessResult(Messages.CardAdded);
		}

		[SecuredOperation("admin,personnel")]
		[CacheRemoveAspect("ICardService.Get")]
		public IResult Delete(int id)
		{
			_cardDal.Delete(_cardDal.Get(p => p.CardId == id));
			return new SuccessResult(Messages.CardDeleted);
		}

		[ValidationAspect(typeof(CardValidator))]
		[SecuredOperation("admin,personnel")]
		[CacheRemoveAspect("ICardService.Get")]
		public IResult Update(Card card)
		{
			_cardDal.Update(card);
			return new SuccessResult(Messages.CardUpdated);
		}

		[SecuredOperation("admin,personnel")]
		[CacheAspect(duration: 10)]
		public IDataResult<List<Card>> GetAll()
		{
			return new SuccessDataResult<List<Card>>(_cardDal.GetAll(), Messages.CardsListed);
		}

		[SecuredOperation("admin,personnel")]
		public IDataResult<Card> GetById(int cardId)
		{
			return new SuccessDataResult<Card>(_cardDal.Get(p => p.CardId == cardId), Messages.CardViewed);
		}
	}
}
