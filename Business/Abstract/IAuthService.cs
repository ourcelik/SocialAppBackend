using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthService
    {
        Task<IDataResult<Entities.Concrete.User>> RegisterAsync(UserForRegisterDto userForRegisterDto);
        Task<IDataResult<Entities.Concrete.User>> LoginAsync(UserForLoginDto userForLoginDto);
        Task<IResult> UserExistsAsync(string email);
        IDataResult<AccessToken> CreateAccessToken(Entities.Concrete.User user);
    }
}
