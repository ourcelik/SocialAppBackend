using Business.Abstract;
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
        IBankDal _bankDal;
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

        public IDataResult<UserSpecificCoin> GetCooperCoinByUserIdAsync(int id)
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

        public IDataResult<List<UserSpecificCoin>> GetCopperCoinWalletsAsync()
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

        public IDataResult<UserSpecificCoin> GetGoldCoinByUserIdAsync(int id)
        {
            UserSpecificCoin data;
            try
            {
                data = _bankDal.getgol(id);
            }
            catch (Exception)
            {

                return new ErrorDataResult<UserSpecificCoin>();
            }
            return new SuccessDataResult<UserSpecificCoin>(data);
        }

        public IDataResult<List<UserSpecificCoin>> GetGoldCoinWalletsAsync()
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

        public IDataResult<UserSpecificCoin> GetSilverCoinByUserIdAsync(int id)
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

        public IDataResult<List<UserSpecificCoin>> GetSilverCoinWalletsAsync()
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
