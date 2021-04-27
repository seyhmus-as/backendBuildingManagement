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
        public List<FlatDetailDto> GetProductDetails()
        {
            using (BuildingManagementContext context = new BuildingManagementContext())
            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.CategoryId
                             select new FlatDetailDto 
                             {
                                 ProductId = p.ProductId, ProductName = p.ProductName, 
                                 CategoryName =c.CategoryName, UnitsInStock = p.UnitsInStock 
                             };
                return result.ToList();
            }
        }
    }
}
