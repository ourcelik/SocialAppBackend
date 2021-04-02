using Business.Abstract;
using Core.Utilities.Results;
using DataAccess;
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
