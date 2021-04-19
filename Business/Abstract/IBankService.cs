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
        public IDataResult<UserSpecificCoin> GetCooperCoinByUserId(int id);
        public IDataResult<List<UserSpecificCoin>> GetCopperCoinWallets();
        public IDataResult<UserSpecificCoin> GetGoldCoinByUserId(int id);
        public IDataResult<List<UserSpecificCoin>> GetGoldCoinWallets();
        public IDataResult<UserSpecificCoin> GetSilverCoinByUserId(int id);
        public IDataResult<List<UserSpecificCoin>> GetSilverCoinWallets();
    }
}
