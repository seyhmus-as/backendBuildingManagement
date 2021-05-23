using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfUserDal : EfEntityRepositoryBase<User, BuildingManagementContext>, IUserDal
	{
		public List<OperationClaim> GetClaims(User user)
		{
			using (var context = new BuildingManagementContext())
			{
				var result = from operationClaim in context.OperationClaims
							 join userOperationClaim in context.UserOperationClaims
								 on operationClaim.Id equals userOperationClaim.OperationClaimId
							 where userOperationClaim.UserId == user.Id
							 select new OperationClaim
							 {
								 Id = operationClaim.Id,
								 Name = operationClaim.Name
							 };
				return result.ToList();
			}
		}
		public List<UserDetailDto> GetUserDetails()
		{
			using (BuildingManagementContext context = new BuildingManagementContext())
			{
				var result = from o in context.UserOperationClaims
							 join u in context.Users
								on o.UserId equals u.Id
							 join c in context.OperationClaims
								on o.OperationClaimId equals c.Id
							 select new UserDetailDto
							 {
								 UserId = u.Id,
								 Email = u.Email,
								 FirstName = u.FirstName,
								 LastName = u.LastName,
								 OperationClaimId = o.OperationClaimId,
								 OperationName = c.Name
							 };
				return result.ToList();
			}
		}
		public List<UserForShowingDto> GetUserAll()
		{
			using (BuildingManagementContext context = new BuildingManagementContext())
			{
				var result = from u in context.Users
							 select new UserForShowingDto
							 {
								 UserId = u.Id,
								 Email = u.Email,
								 FirstName = u.FirstName,
								 LastName = u.LastName,
							 };
				return result.ToList();
			}
		}

	}
}
