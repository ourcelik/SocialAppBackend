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

        [SecuredOperationAspect("Admin")]
        async public Task<IDataResult<List<Bank>>> GetAllAsync()
        {
            List<Bank> data;
            try
            {
                data = await _bankDal.GetAllAsync();


            }
            catch (Exception)
            {

                return new ErrorDataResult<List<Bank>>();
            }
            return new SuccessDataResult<List<Bank>>(data);
        }
        public IDataResult<UserCoinBankDto> GetCoinsByUserId(int id)
        {
            UserCoinBankDto data;
            try
            {
                data = _bankDal.GetCoinsByUserId(id);
            }
            catch (Exception)
            {

                return new ErrorDataResult<UserCoinBankDto>();
            }
            return new SuccessDataResult<UserCoinBankDto>(data);
        }

        public IDataResult<UserSpecificCoinDto> GetCooperCoinByUserId(int id)
        {
            UserSpecificCoinDto data;
            try
            {
                data = _bankDal.GetCooperCoinByUserId(id);
            }
            catch (Exception)
            {

                return new ErrorDataResult<UserSpecificCoinDto>();
            }
            return new SuccessDataResult<UserSpecificCoinDto>(data);
        }
        
        public IDataResult<List<UserSpecificCoinDto>> GetCopperCoinWallets()
        {
            List<UserSpecificCoinDto> data;
            try
            {
                data = _bankDal.GetCopperCoinWallets();
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<UserSpecificCoinDto>>();
            }
            return new SuccessDataResult<List<UserSpecificCoinDto>>(data);
        }

        public IDataResult<UserSpecificCoinDto> GetGoldCoinByUserId(int id)
        {
            UserSpecificCoinDto data;
            try
            {
                data = _bankDal.GetGoldCoinByUserId(id);
            }
            catch (Exception)
            {

                return new ErrorDataResult<UserSpecificCoinDto>();
            }
            return new SuccessDataResult<UserSpecificCoinDto>(data);
        }
        
        public IDataResult<List<UserSpecificCoinDto>> GetGoldCoinWallets()
        {
            List<UserSpecificCoinDto> data;
            try
            {
                data = _bankDal.GetGoldCoinWallets();
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<UserSpecificCoinDto>>();
            }
            return new SuccessDataResult<List<UserSpecificCoinDto>>(data);
        }
        
        public IDataResult<UserSpecificCoinDto> GetSilverCoinByUserId(int id)
        {
            UserSpecificCoinDto data;
            try
            {
                data = _bankDal.GetSilverCoinByUserId(id);
            }
            catch (Exception)
            {

                return new ErrorDataResult<UserSpecificCoinDto>();
            }
            return new SuccessDataResult<UserSpecificCoinDto>(data);
        }
        
        public IDataResult<List<UserSpecificCoinDto>> GetSilverCoinWallets()
        {
            List<UserSpecificCoinDto> data;
            try
            {
                data = _bankDal.GetSilverCoinWallets();
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<UserSpecificCoinDto>>();
            }
            return new SuccessDataResult<List<UserSpecificCoinDto>>(data);
        }
    }
}
