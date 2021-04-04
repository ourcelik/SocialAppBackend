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
    public interface IBankService
    {
        public Task<IDataResult<List<Bank>>> GetAllAsync();
        public IDataResult<UserCoinBank> GetCoinsByUserId(int id);
        public IDataResult<UserSpecificCoin> GetCooperCoinByUserIdAsync(int id);
        public IDataResult<List<UserSpecificCoin>> GetCopperCoinWalletsAsync();
        public IDataResult<UserSpecificCoin> GetGoldCoinByUserIdAsync(int id);
        public IDataResult<List<UserSpecificCoin>> GetGoldCoinWalletsAsync();
        public IDataResult<UserSpecificCoin> GetSilverCoinByUserIdAsync(int id);
        public IDataResult<List<UserSpecificCoin>> GetSilverCoinWalletsAsync();
    }
}
