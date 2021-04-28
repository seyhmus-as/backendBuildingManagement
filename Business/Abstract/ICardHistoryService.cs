using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
	public interface ICardHistoryService
	{
		IResult Add(CardHistory cardHistory);
		IResult Delete(int id);
		IResult Update(CardHistory cardHistory);
		IDataResult<List<CardHistory>> GetAll();
		IDataResult<List<CardHistory>> GetById(int cardId);
		IDataResult<List<CardHistoryDetailDto>> GetMonthMoneyById(int flatId, int secondBegin, int secondFinal, bool isIncome);
		IDataResult<int> GetMonthMoneyTotalById(int flatId, int secondBegin, int secondFinal, bool isIncome);
		IDataResult<int> GetMonthMoney(int secondBegin, int secondFinal, bool isIncome);
		IDataResult<List<CardHistoryDetailDto>> GetCardHistoryDetails();
	}
}
