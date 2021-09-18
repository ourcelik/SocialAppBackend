using AutoMapper;
using Business.Abstract;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Utilities.Business;
using Core.Utilities.IoC;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProfileManager : IProfileService
    {
        readonly IProfileDal _profileDal;
        readonly IMapper _mapper;
        public ProfileManager(IProfileDal profileDal,IMapper mapper)
        {
            _profileDal = profileDal;
            _mapper = mapper;

        }

        async public Task<IDataResult<int>> AddAsync(Entities.Concrete.Profile entity)
        {
            var result =  await _profileDal.AddAsync(entity);

            return new SuccessDataResult<int>(result.ProfileId);
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
            if (!IsSameUser(entity))
            {
                throw new Exception("Permission Denied");
            }

            var data = await GetByIdAsync(entity.ProfileId);
            var profile = _mapper.Map<Entities.Concrete.Profile>(entity);
            CompleteProfile(data.Data, profile);

            var result = await _profileDal.UpdateAsync(profile);

            return new SuccessDataResult<int>(profile.ProfileId);
        }

        private static void CompleteProfile(Entities.Concrete.Profile profile, Entities.Concrete.Profile notCompleteProfile)
        {
            notCompleteProfile.ProfileId = profile.ProfileId;
            notCompleteProfile.NotificationId = profile.NotificationId;
            notCompleteProfile.PreferId = profile.PreferId;
            notCompleteProfile.ProfilePhotoId = profile.ProfilePhotoId;
        }

        private bool IsSameUser(UserUpdateProfileDto entity)
        {
            var currentUsername = SecuredUserOperationHelpers.GetCurrentUsername();
            var CurrentUserProfile = GetByUsername(currentUsername);
            if(entity.ProfileId != CurrentUserProfile.Data.ProfileId)
            {
                return false;
            }
            return true;
        }
    }
}
