using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
	public interface IRenterService
	{
		IResult Add(Renter renter);
		IResult Delete(int renterId);
		IResult Update(Renter renter);
		IDataResult<List<Renter>> GetAll();
		IDataResult<Renter> GetById(int renterId);
		IDataResult<List<RenterDetailDto>> GetRenterDetails();
	}
}
