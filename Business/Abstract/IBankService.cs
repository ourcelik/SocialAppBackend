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
        public IDataResult<UserCoinBankDto> GetCoinsByUserId(int id);
        public IDataResult<UserSpecificCoinDto> GetCooperCoinByUserId(int id);
        public IDataResult<List<UserSpecificCoinDto>> GetCopperCoinWallets();
        public IDataResult<UserSpecificCoinDto> GetGoldCoinByUserId(int id);
        public IDataResult<List<UserSpecificCoinDto>> GetGoldCoinWallets();
        public IDataResult<UserSpecificCoinDto> GetSilverCoinByUserId(int id);
        public IDataResult<List<UserSpecificCoinDto>> GetSilverCoinWallets();
        public Task<IDataResult<int>> AddBankAccount(Bank bank);
    }
}
