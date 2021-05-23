using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);
        void Add(User user);
        User GetByMail(string email);
        IResult Delete(string email);
        IDataResult<List<UserDetailDto>> GetUserDetails();
        IDataResult<List<UserForShowingDto>> GetUserAll();
    }
}
