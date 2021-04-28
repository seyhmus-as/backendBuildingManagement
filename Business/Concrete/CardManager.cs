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
	public class CardManager : ICardService
	{
		ICardDal _cardDal;
		public CardManager(ICardDal cardDal)
		{
			_cardDal = cardDal;
		}
		[SecuredOperation("admin")]
		[CacheRemoveAspect("ICardService.Get")]
		public IResult Add(Card card)
		{
			_cardDal.Add(card);
			return new SuccessResult(Messages.CustomerAdded);
		}
		[SecuredOperation("admin")]
		public IResult Delete(int id)
		{
			_cardDal.Delete(_cardDal.Get(p => p.CardId == id));
			return new SuccessResult(Messages.CustomerDeleted);
		}
		[SecuredOperation("admin")]
		[CacheRemoveAspect("ICardService.Get")]
		public IResult Update(Card card)
		{
			/*var updatedL = _customerDal.Get(p => p.Id == customer.Id);
 			_customerDal.Update(updatedL);*/
			_cardDal.Update(card);
			return new SuccessResult(Messages.CustomerUpdate);
		}
		[SecuredOperation("admin")]
		[CacheAspect]
		public IDataResult<List<Card>> GetAll()
		{
			return new SuccessDataResult<List<Card>>(_cardDal.GetAll(), Messages.CustomersListed);
		}
		[SecuredOperation("admin")]
		public IDataResult<Card> GetById(int cardId)
		{
			return new SuccessDataResult<Card>(_cardDal.Get(p => p.CardId == cardId));
		}
	}
}
