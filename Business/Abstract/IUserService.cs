using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        Task<IResult> AddAsync(User entity);
        Task<IDataResult<User>> GetByEmailAsync(string email);
        Task<IDataResult<User>> GetByUserNameAsync(string userName);
        Task<IDataResult<User>> GetByTelNoAsync(string telNo);
        Task<IResult> UpdateUserAsync(User entity);

    }
}
