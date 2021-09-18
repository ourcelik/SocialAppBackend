using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProfileService
    {

        public IDataResult<UserProfileDto> GetByEmail(string email);
        public IDataResult<UserProfileDto> GetByTelNo(string telNo);
        public IDataResult<UserProfileDto> GetByUsername(string userName);
        public Task<IDataResult<int>> AddAsync(Profile entity);
        public Task<IDataResult<List<Profile>>> GetAllAsync();
        public Task<IDataResult<int>> UpdateUserProfileAsync(UserUpdateProfileDto entity);
        public Task<IDataResult<Profile>> GetByIdAsync(int id);

    }
}
