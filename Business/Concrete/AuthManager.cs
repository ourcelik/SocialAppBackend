using Business.Abstract;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<AccessToken> CreateAccessToken(Entities.Concrete.User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims.Data);
            return new SuccessDataResult<AccessToken>(accessToken, "Token üretildi");
        }

        public async Task<IDataResult<Entities.Concrete.User>> LoginAsync(UserForLoginDto userForLoginDto)
        {
            var tasks = new List<Task>();
            var userToCheckMail = await _userService.GetByEmailAsync(userForLoginDto.UserLoginInfo);
            var userToCheckUsername = await _userService.GetByUserNameAsync(userForLoginDto.UserLoginInfo);
            var userToCheckPhonoNumber = await _userService.GetByTelNoAsync(userForLoginDto.UserLoginInfo);
            if (!IsNotNull(userToCheckPhonoNumber.Data) && !IsNotNull(userToCheckUsername.Data) && !IsNotNull(userToCheckMail.Data))
            {
                return new ErrorDataResult<Entities.Concrete.User>("Giriş Başarısız");
            }
            if(!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheckMail.Data.PasswordHash,
                userToCheckMail.Data.PasswordSalt))
            {
                return new ErrorDataResult<Entities.Concrete.User>("Giriş Başarısız");
            }
            return new SuccessDataResult<Entities.Concrete.User>(userToCheckMail.Data, "Başarılı bir Şekilde giriş yapıldı");

        }

        public async Task<IDataResult<Entities.Concrete.User>> RegisterAsync(UserForRegisterDto userForRegisterDto)
        {
            byte[] passwordHash, PasswordSalt;
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password,out passwordHash, out PasswordSalt);
            var user = new Entities.Concrete.User
            {
                Mail = userForRegisterDto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = PasswordSalt,
                Status = true,
                TelNo = userForRegisterDto.PhoneNumber,
                Username = userForRegisterDto.Username,
                CoinBankId = 1,
                ProfileId = 1
                
            };
            await _userService.AddAsync(user);
            return new SuccessDataResult<Entities.Concrete.User>(user, "Kayıt başarılı");
        }

        public async Task<IResult> UserExistsAsync(string email)
        {
            var data = await _userService.GetByEmailAsync(email);
            if (!data.Success)
            {
                return new ErrorResult("Kullanıcı zaten mevcut");
            }
            return new SuccessResult();
        }
        public bool IsNotNull(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            return true;
        }
    }
}
