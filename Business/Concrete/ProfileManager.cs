using Business.Abstract;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
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
    public class ProfileManager : IProfileService
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

        [CacheAspect]
        public IDataResult<UserProfileDto> GetByEmail(string email)
        {
            UserProfileDto user;
            try
            {
                user = _profileDal.GetUserProfileByMail(email);

            }
            catch (Exception)
            {
                return new ErrorDataResult<UserProfileDto>();
            }
            return new SuccessDataResult<UserProfileDto>(user);
        }

        [CacheAspect]
        public IDataResult<UserProfileDto> GetByTelNo(string telNo)
        {
            UserProfileDto user;
            try
            {
                user = _profileDal.GetUserProfileByTelNo(telNo);

            }
            catch (Exception)
            {
                return new ErrorDataResult<UserProfileDto>();
            }
            return new SuccessDataResult<UserProfileDto>(user);
        }

        [CacheAspect]
        public IDataResult<UserProfileDto> GetByUsername(string userName)
        {
            UserProfileDto user;
            try
            {
                user = _profileDal.GetUserProfileByUsername(userName);

            }
            catch (Exception)
            {
                return new ErrorDataResult<UserProfileDto>();
            }
            return new SuccessDataResult<UserProfileDto>(user);
        }

        async public Task<IDataResult<List<Profile>>> GetAllAsync()
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
            return new SuccessDataResult<List<Profile>>(profiles);
        }

        [CacheAspect]
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
