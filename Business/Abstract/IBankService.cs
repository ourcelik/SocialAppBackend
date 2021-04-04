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
        public  Task<List<UserSpecificCoin>> GetCopperCoinWalletsAsync();
        public  Task<List<UserSpecificCoin>> GetGoldCoinWalletsAsync();
        public  Task<List<UserSpecificCoin>> GetSilverCoinWalletsAsync();
        public  Task<UserCoinBank> GetCoinsByUserIdAsync(int id);
        public  Task<UserSpecificCoin> GetCooperCoinByUserIdAsync(int id);
        public  Task<UserSpecificCoin> GetSilverCoinByUserIdAsync(int id);
        public  Task<UserSpecificCoin> GetGoldCoinByUserIdAsync(int id);
    }
}
