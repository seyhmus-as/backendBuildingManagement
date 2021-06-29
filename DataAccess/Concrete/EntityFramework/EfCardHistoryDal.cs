using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfCardHistoryDal : EfEntityRepositoryBase<CardHistory, BuildingManagementContext>, ICardHistoryDal
	{
		public List<CardHistoryDetailDto> GetCardHistoryDetails()
		{
			using (BuildingManagementContext context = new BuildingManagementContext())
			{
				var result = from c in context.Cards
							 join p in context.CardHistories
							 on c.Id equals p.CardId
							 select new CardHistoryDetailDto
							 {
								 IsIncome = c.IsIncome,
								 Price = p.Price,
								 Id = p.Id,
								 Name = c.Name,
								 Date = p.Date,
								 CardId = c.Id,
								 FlatId = p.FlatId,
							 };
				return result.ToList();
			}
		}
	}
}
