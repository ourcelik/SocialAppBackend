using Business.Abstract;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
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
        public IDataResult<UserCoinBank> GetCoinsByUserId(int id)
        {
            UserCoinBank data;
            try
            {
                data = _bankDal.GetCoinsByUserId(id);
            }
            catch (Exception)
            {

                return new ErrorDataResult<UserCoinBank>();
            }
            return new SuccessDataResult<UserCoinBank>(data);
        }

        public IDataResult<UserSpecificCoin> GetCooperCoinByUserId(int id)
        {
            UserSpecificCoin data;
            try
            {
                data = _bankDal.GetCooperCoinByUserId(id);
            }
            catch (Exception)
            {

                return new ErrorDataResult<UserSpecificCoin>();
            }
            return new SuccessDataResult<UserSpecificCoin>(data);
        }
        
        public IDataResult<List<UserSpecificCoin>> GetCopperCoinWallets()
        {
            List<UserSpecificCoin> data;
            try
            {
                data = _bankDal.GetCopperCoinWallets();
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<UserSpecificCoin>>();
            }
            return new SuccessDataResult<List<UserSpecificCoin>>(data);
        }

        public IDataResult<UserSpecificCoin> GetGoldCoinByUserId(int id)
        {
            UserSpecificCoin data;
            try
            {
                data = _bankDal.GetGoldCoinByUserId(id);
            }
            catch (Exception)
            {

                return new ErrorDataResult<UserSpecificCoin>();
            }
            return new SuccessDataResult<UserSpecificCoin>(data);
        }
        
        public IDataResult<List<UserSpecificCoin>> GetGoldCoinWallets()
        {
            List<UserSpecificCoin> data;
            try
            {
                data = _bankDal.GetGoldCoinWallets();
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<UserSpecificCoin>>();
            }
            return new SuccessDataResult<List<UserSpecificCoin>>(data);
        }
        
        public IDataResult<UserSpecificCoin> GetSilverCoinByUserId(int id)
        {
            UserSpecificCoin data;
            try
            {
                data = _bankDal.GetSilverCoinByUserId(id);
            }
            catch (Exception)
            {

                return new ErrorDataResult<UserSpecificCoin>();
            }
            return new SuccessDataResult<UserSpecificCoin>(data);
        }
        
        public IDataResult<List<UserSpecificCoin>> GetSilverCoinWallets()
        {
            List<UserSpecificCoin> data;
            try
            {
                data = _bankDal.GetSilverCoinWallets();
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<UserSpecificCoin>>();
            }
            return new SuccessDataResult<List<UserSpecificCoin>>(data);
        }
    }
}
