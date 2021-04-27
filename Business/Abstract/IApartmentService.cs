using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IApartmentService
    {
        IResult Add(Apartment apartment);
        IResult Delete(int carId);
        IResult Update(Apartment apartment);
        IDataResult<List<Apartment>> GetAll();
        IDataResult<Apartment> GetById(int apartmentId);

    }
}
