using Business.Abstract;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
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

        [PerformanceAspect(5)]
        async public Task<IResult> AddAsync(User user)
        {
            try
            {
                await _userDal.AddAsync(user);
            }
            catch (Exception)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        async public Task<IDataResult<User>> GetByEmailAsync(string email)
        {
            User user;
            try
            {
                user = await _userDal.GetAsync(u => u.Mail == email);
            }
            catch (Exception)
            {
                return new ErrorDataResult<User>();
            }
            return new SuccessDataResult<User>(user);
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        async public Task<IDataResult<User>>  GetByTelNoAsync(string telNo)
        {
            User user;
            try
            {
                user = await _userDal.GetAsync(u => u.TelNo == telNo);
            }
            catch (Exception)
            {
                return new ErrorDataResult<User>();
            }
            return new SuccessDataResult<User>(user);
        }
        [CacheAspect]
        [PerformanceAspect(5)]
        async public Task<IDataResult<User>> GetByUserNameAsync(string userName)
        {
            User user;
            try
            {
                user = await _userDal.GetAsync(u => u.Username == userName);
            }
            catch (Exception)
            {
                return new ErrorDataResult<User>();
            }
            return new SuccessDataResult<User>(user);
        }

        [PerformanceAspect(5)]
        async public Task<IResult> UpdateUserAsync(User user)
        {
            try
            {
                await _userDal.UpdateAsync(user);
            }
            catch (Exception)
            {

                return new ErrorResult();
            }
            return new SuccessResult();
        }

       
    }
}
