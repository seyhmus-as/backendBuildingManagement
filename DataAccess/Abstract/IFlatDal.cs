using Entities.DTOs;
using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IFlatDal:IEntityRepository<Flat>
    {

        List<FlatDetailDto> GetFlatDetails();
    }
}
