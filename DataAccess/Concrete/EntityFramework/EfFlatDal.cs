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
                var result = from flat in context.Flats
                             join apartment in context.Apartments
                             on flat.ApartmentId equals apartment.Id
                             join renter in context.Renters
                             on flat.RenterId equals renter.Id
                             select new FlatDetailDto
                             {
                                 Id = flat.Id,
                                 FlatNo = flat.FlatNo,
                                 RenterId = renter.Id,
                                 ApartmentId = apartment.Id,
                                 ApartmentName = apartment.Name,
                                 PriceOfRent = flat.PriceOfRent,
                                 RenterName = renter.FirstName + " " +renter.LastName
                             };
                return result.ToList();
            }
        }
    }
}
