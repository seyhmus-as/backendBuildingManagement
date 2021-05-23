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
    public class EfRenterDal : EfEntityRepositoryBase<Renter, BuildingManagementContext>, IRenterDal
    {
        public List<RenterDetailDto> GetRenterDetails()
        {
            using (BuildingManagementContext context = new BuildingManagementContext())
            {
                var result = from p in context.Flats
                             join c in context.Apartments
                             on p.ApartmentId equals c.ApartmentId
                             join r in context.Renters
                             on p.RenterId equals r.RenterId
                             select new RenterDetailDto
                             {
                                 ApartmentName = c.ApartmentName,
                                 ApartmentId = c.ApartmentId,
                                 FlatId = p.FlatId,
                                 PriceOfRent = p.PriceOfRent,
                                 RenterId = p.RenterId,
                                 RenterName = r.FirstName + " " + r.LastName
                             };
                return result.ToList();
            }
        }

    }
}
