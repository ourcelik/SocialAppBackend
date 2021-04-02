using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    class ProfileManager : IProfileService
    {
        readonly IProfileDal _profileDal;
        public ProfileManager(IProfileDal profileDal)
        {
            _profileDal = profileDal;
        }
        async public Task<IResult> AddAsync(Profile entity)
        {
            try
            {
                await _profileDal.AddAsync(entity);
            }
            catch (Exception)
            {

                return new ErrorResult();
            }
            return new SuccessResult();
        }

         public IDataResult<UserProfile> GetByEmail(string email)
        {
            UserProfile user;
            try
            {
                user = _profileDal.GetUserProfileByMail(email);

            }
            catch (Exception)
            {
                return new ErrorDataResult<UserProfile>();
            }
            return new SuccessDataResult<UserProfile>(user);
        }

        public IDataResult<UserProfile> GetByTelNo(string telNo)
        {
            UserProfile user;
            try
            {
                user = _profileDal.GetUserProfileByTelNo(telNo);

            }
            catch (Exception)
            {
                return new ErrorDataResult<UserProfile>();
            }
            return new SuccessDataResult<UserProfile>(user);
        }

        public IDataResult<UserProfile> GetByUserName(string userName)
        {
            UserProfile user;
            try
            {
                user = _profileDal.GetUserProfileByUserName(userName);

            }
            catch (Exception)
            {
                return new ErrorDataResult<UserProfile>();
            }
            return new SuccessDataResult<UserProfile>(user);
        }

        async public Task<IDataResult<List<Profile>>> GetFullUserProfilesAsync()
        {
            List<Profile> profiles;
            try
            {
                  profiles = await _profileDal.GetAllAsync();

            }
            catch (Exception)
            {

                return new ErrorDataResult<List<Profile>>();
            }
            return new SuccessDataResult<List<Profile>>();
        }

        async public Task<IResult> UpdateUserProfileAsync(Profile entity)
        {
            try
            {
                await _profileDal.UpdateAsync(entity);
            }
            catch (Exception)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}
