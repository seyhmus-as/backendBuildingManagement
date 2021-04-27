using Business.Abstract;
using Business.BusinessAspects.Autofac;
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
	public class CardManager : ICardService
	{
		ICardDal _cardDal;
		public CardManager(ICardDal cardDal)
		{
			_cardDal = cardDal;
		}	
		public IResult Add(Card card)
		{
			_cardDal.Add(card);
			return new SuccessResult(Messages.CustomerAdded);
		}
		public IResult Delete(int id)
		{
			_cardDal.Delete(_cardDal.Get(p => p.CardId == id));
			return new SuccessResult(Messages.CustomerDeleted);
		}
		public IResult Update(Card card)
		{
			/*var updatedL = _customerDal.Get(p => p.Id == customer.Id);
 			_customerDal.Update(updatedL);*/
			_cardDal.Update(card);
			return new SuccessResult(Messages.CustomerUpdate);
		}
		public IDataResult<List<Card>> GetAll()
		{
			return new SuccessDataResult<List<Card>>(_cardDal.GetAll(), Messages.CustomersListed);
		}
		public IDataResult<Card> GetById(int cardId)
		{
			return new SuccessDataResult<Card>(_cardDal.Get(p => p.CardId == cardId));
		}
	}
}
