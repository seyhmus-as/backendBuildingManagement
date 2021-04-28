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
		IDataResult<List<CardHistoryDetailDto>> GetMonthlyMoneyById(int flatId, int secondBegin, int secondFinal, bool isIncome);
		IDataResult<int> GetMonthlyMoneyTotalById(int flatId, int secondBegin, int secondFinal, bool isIncome);
		IDataResult<int> GetMonthlyMoney(int secondBegin, int secondFinal, bool isIncome);
		IDataResult<List<CardHistoryDetailDto>> GetCardHistoryDetails();
	}
}
