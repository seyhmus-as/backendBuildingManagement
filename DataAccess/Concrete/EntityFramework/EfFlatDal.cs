using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfFlatDal : EfEntityRepositoryBase<Flat, BuildingManagementContext>, IFlatDal
    {
        public List<FlatDetailDto> GetFlatDetails()
        {
            using (BuildingManagementContext context = new BuildingManagementContext())
            {
                var result = from p in context.Flats
                             join c in context.Apartments
                             on p.ApartmentId equals c.ApartmentId
                             select new FlatDetailDto
                             {
                                 ApartmentName=c.ApartmentName,
                                 ApartmentId=c.ApartmentId,
                                 FlatId=p.FlatId,
                                 PriceOfRent=p.PriceOfRent,
                                 Renter=p.Renter
                             };
                return result.ToList();
            }
        }
    }
}
