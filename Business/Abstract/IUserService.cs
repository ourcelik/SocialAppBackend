using Core.Entities.Concrete;
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
        Task<IResult> AddAsync(Entities.Concrete.User user);
        IDataResult<List<OperationClaim>> GetClaims(Entities.Concrete.User user);
        Task<IDataResult<Entities.Concrete.User>> GetByEmailAsync(string email);
        Task<IDataResult<Entities.Concrete.User>> GetByUserNameAsync(string userName);
        Task<IDataResult<Entities.Concrete.User>> GetByTelNoAsync(string telNo);

    }
}
