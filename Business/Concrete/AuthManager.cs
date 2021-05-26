using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IOperationClaimDal _operationClaimDal;
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper, IOperationClaimDal operationClaimDal)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _operationClaimDal = operationClaimDal;
        }

        [LogAspect(typeof(FileLogger))]
        [LogAspect(typeof(DatabaseLogger))]
        [SecuredOperation("admin")]
        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, "Kayıt oldu");
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.WrongPassword);
            }

            return new SuccessDataResult<User>(userToCheck, Messages.SuccessLogin);
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email) != null)
            {
                return new ErrorResult(Messages.EmailUsed);
            }
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken);
        }

        [SecuredOperation("admin")]
        public IDataResult<List<OperationClaim>> GetAllClaims()
        {
            return new SuccessDataResult<List<OperationClaim>>(_operationClaimDal.GetAll(), Messages.OperationClaimsListed);
        }
    }
}
