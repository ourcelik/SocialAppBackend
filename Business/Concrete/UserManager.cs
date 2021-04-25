using Business.Abstract;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        readonly IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public async Task<IResult> AddAsync(Entities.Concrete.User user)
        {
            await _userDal.AddAsync(user);
            return new SuccessResult();
        }

        public async Task<IDataResult<Entities.Concrete.User>> GetByEmailAsync(string email)
        {
            var data =  await _userDal.GetAsync(u => u.Mail == email);
            return new SuccessDataResult<Entities.Concrete.User>(data);
        }

        public async Task<IDataResult<Entities.Concrete.User>> GetByTelNoAsync(string telNo)
        {
            var data = await _userDal.GetAsync(u => u.TelNo == telNo);
            return new SuccessDataResult<Entities.Concrete.User>(data);
        }

        public async Task<IDataResult<Entities.Concrete.User>> GetByUserNameAsync(string userName)
        {
            var data = await _userDal.GetAsync(u => u.Username == userName);
            return new SuccessDataResult<Entities.Concrete.User>(data);
        }

        public IDataResult<List<OperationClaim>> GetClaims(Entities.Concrete.User user)
        {
            var data =_userDal.GetClaims(user);
            return new SuccessDataResult<List<OperationClaim>>(data);
        }
    }
}
