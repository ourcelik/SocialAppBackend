using Business.Abstract;
using Core.Utilities.Business;
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
        private IBankService _bankService;
        private IProfileService _profileService;
        private ITokenHelper _tokenHelper;
        private IPreferService _preferService;
        private INotificationService _notificationService;

        public AuthManager(IUserService userService,
            ITokenHelper tokenHelper,
            IBankService bankService,
            IProfileService profileService,
            IPreferService preferService,
            INotificationService notificationService)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _bankService = bankService;
            _profileService = profileService;
            _preferService = preferService;
            _notificationService = notificationService;
        }

        public IDataResult<AccessToken> CreateAccessToken(Entities.Concrete.User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims.Data);

            return new SuccessDataResult<AccessToken>(accessToken, "Token üretildi");
        }

        public async Task<IDataResult<User>> LoginAsync(UserForLoginDto userForLoginDto)
        {
            IDataResult<User> user = await GetUserFromDb(userForLoginDto);

            if (!user.Success)
            {
                return new ErrorDataResult<User>("Sistemde Eşleşme Bulunamadı,Giriş Başarısız");
            }
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, user.Data.PasswordHash, user.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>("Hatalı Kullanıcı Bilgisi Girildi");
            }
            return new SuccessDataResult<User>(user.Data, "Başarılı bir Şekilde giriş yapıldı");
        }

        private async Task<IDataResult<User>> GetUserFromDb(UserForLoginDto userForLoginDto)
        {
            var userToCheckMail = _userService.GetByEmailAsync(userForLoginDto.UserLoginInfo);
            var userToCheckUsername = _userService.GetByUserNameAsync(userForLoginDto.UserLoginInfo);
            var userToCheckPhonoNumber = _userService.GetByTelNoAsync(userForLoginDto.UserLoginInfo);
            var tasks = new List<Task<IDataResult<User>>>()
            {
                userToCheckMail,
                userToCheckUsername,
                userToCheckPhonoNumber
            };
            var UserValidationFromDb = await Task.WhenAll(tasks);

            var user = IsNotNull(UserValidationFromDb);
            return user;
        }

        public async Task<IDataResult<User>> RegisterAsync(UserForRegisterDto userForRegisterDto)
        {

            byte[] passwordHash, PasswordSalt;
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out PasswordSalt);
            
            IDataResult<int> accountResult = await CreateUserBankAcount();

            //#region prefer
            //var preferSettings = new Prefer
            //{
            //    AppVoice = false,
            //    Autoplay = false,
            //    GenderPreferId = 0,
            //    LastSeen = false,
            //    MaxAge = 30,
            //    MaxDistance = 30,
            //    MinAge = 18,
            //    ShowMe = false,
            //    Universal = false

            //};
            //var preferResult = await _preferService.AddPreferSetting(preferSettings);

            //#endregion

            var user = new User
            {
                Mail = userForRegisterDto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = PasswordSalt,
                Status = true,
                TelNo = userForRegisterDto.PhoneNumber,
                Username = userForRegisterDto.Username,
                CoinBankId = accountResult.Data,
                ProfileId = 1


            };
            await _userService.AddAsync(user);
            return new SuccessDataResult<User>(user, "Kayıt başarılı");
        }

        private async Task<IDataResult<int>> CreateUserBankAcount()
        {
            var bankAccount = new Bank
            {
                CopperCoin = 10,
                GoldCoin = 1,
                SilverCoin = 100
            };
            var accountResult = await _bankService.AddBankAccount(bankAccount);
            return accountResult;
        }

        public async Task<IResult> UserExistsAsync(string email)
        {
            var data = await _userService.GetByEmailAsync(email);

            return !data.Success ? new ErrorResult("Kullanıcı zaten mevcut") : new SuccessResult();
        }
        public IDataResult<T> IsNotNull<T>(params IDataResult<T>[] objects)
        {
            foreach (var item in objects)
            {
                if (item.Data != null)
                {
                    return item;
                }
            }
            return new ErrorDataResult<T>();

        }
    }
}
