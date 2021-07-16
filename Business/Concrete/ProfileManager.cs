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
            await _profileDal.AddAsync(entity);

            return new SuccessResult();
        }

        public IDataResult<UserProfileDto> GetByEmail(string email)
        {
            var user = _profileDal.GetUserProfileByMail(email);

            return new SuccessDataResult<UserProfileDto>(user);
        }

        public IDataResult<UserProfileDto> GetByTelNo(string telNo)
        {
            var user = _profileDal.GetUserProfileByTelNo(telNo);

            return new SuccessDataResult<UserProfileDto>(user);
        }

        public IDataResult<UserProfileDto> GetByUsername(string userName)
        {
            var user = _profileDal.GetUserProfileByUsername(userName);

            return new SuccessDataResult<UserProfileDto>(user);
        }

        async public Task<IDataResult<List<Profile>>> GetAllAsync()
        {
            var profiles = await _profileDal.GetAllAsync();

            return new SuccessDataResult<List<Profile>>(profiles);
        }

        async public Task<IResult> UpdateUserProfileAsync(Profile entity)
        {
            await _profileDal.UpdateAsync(entity);

            return new SuccessResult();
        }
    }
}
