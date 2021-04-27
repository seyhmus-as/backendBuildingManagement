using Core.Utilities.Results;
using Entities.Concrete;
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
		IDataResult<List<CardHistory>> GetById(int carId);
	}
}
