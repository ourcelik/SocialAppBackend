using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Exception;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Performance;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BankManager : IBankService
    {
        readonly IBankDal _bankDal;
        public BankManager(IBankDal bankDal)
        {
            _bankDal = bankDal;
        }

        public async Task<IDataResult<int>> AddBankAccount(Bank bank)
        {
           var data = await  _bankDal.AddAsync(bank);
            return new SuccessDataResult<int>(data.BankId);
        }

        [ExceptionLogAspect(typeof(FileLogger))]
        async public Task<IDataResult<List<Bank>>> GetAllAsync()
        {
            var data = await _bankDal.GetAllAsync();

            return new SuccessDataResult<List<Bank>>(data);
        }
        public IDataResult<UserCoinBankDto> GetCoinsByUserId(int id)
        {
            var data = _bankDal.GetCoinsByUserId(id);

            return new SuccessDataResult<UserCoinBankDto>(data);
        }

        public IDataResult<UserSpecificCoinDto> GetCooperCoinByUserId(int id)
        {
            var data = _bankDal.GetCooperCoinByUserId(id);

            return new SuccessDataResult<UserSpecificCoinDto>(data);
        }

        public IDataResult<List<UserSpecificCoinDto>> GetCopperCoinWallets()
        {
            var data = _bankDal.GetCopperCoinWallets();

            return new SuccessDataResult<List<UserSpecificCoinDto>>(data);
        }

        public IDataResult<UserSpecificCoinDto> GetGoldCoinByUserId(int id)
        {
            var data = _bankDal.GetGoldCoinByUserId(id);
            return new SuccessDataResult<UserSpecificCoinDto>(data);
        }

        public IDataResult<List<UserSpecificCoinDto>> GetGoldCoinWallets()
        {
            var data = _bankDal.GetGoldCoinWallets();

            return new SuccessDataResult<List<UserSpecificCoinDto>>(data);
        }

        public IDataResult<UserSpecificCoinDto> GetSilverCoinByUserId(int id)
        {
            var data = _bankDal.GetSilverCoinByUserId(id);
            return new SuccessDataResult<UserSpecificCoinDto>(data);
        }

        public IDataResult<List<UserSpecificCoinDto>> GetSilverCoinWallets()
        {
             var   data = _bankDal.GetSilverCoinWallets();
            
            return new SuccessDataResult<List<UserSpecificCoinDto>>(data);
        }
    }
}
