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

        async public Task<IResult> AddAsync(Entities.Concrete.Profile entity)
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
        public async Task<IDataResult<Entities.Concrete.Profile>> GetByIdAsync(int id)
        {
            var user = await _profileDal.GetAsync(p => p.ProfileId == id);

            return new SuccessDataResult<Entities.Concrete.Profile>(user);
        }

        async public Task<IDataResult<List<Entities.Concrete.Profile>>> GetAllAsync()
        {
            var profiles = await _profileDal.GetAllAsync();

            return new SuccessDataResult<List<Entities.Concrete.Profile>>(profiles);
        }

        async public Task<IDataResult<int>> UpdateUserProfileAsync(UserUpdateProfileDto entity)
        {
            var data = await GetByIdAsync(entity.ProfileId);
            var profile = data.Data;
            profile.Name = entity.Name;
            profile.Surname = entity.Surname;
            profile.Weight = entity.Weight;
            profile.Height = entity.Height;
            profile.GenderId = entity.GenderId;
            profile.RelationshipStatus = entity.RelationshipStatus;
            profile.Birthdate = entity.Birthdate;

            var result = await _profileDal.UpdateAsync(profile);

            return new SuccessDataResult<int>(profile.ProfileId);
        }
    }
}
