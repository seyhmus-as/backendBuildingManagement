using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
	public interface IRenterService
	{
		IResult Add(Renter renter);
		IResult Delete(int id);
		IResult Update(Renter renter);
		IDataResult<List<Renter>> GetAll();
		IDataResult<List<Renter>> GetById(int renterId);
	}
}
