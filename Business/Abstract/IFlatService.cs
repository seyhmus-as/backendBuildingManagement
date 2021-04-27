using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IFlatService
    {
        IResult Add(Flat flat);
        IResult Update(Flat flat);
        IResult Delete(int flatId);
        IDataResult<List<Flat>> GetAll();
        IDataResult<Flat> GetById(int carId);
        IDataResult<List<FlatDetailDto>> GetFlatDetails();
        
    }
}
