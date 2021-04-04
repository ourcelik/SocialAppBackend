using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProfileManager : IProfileService
    {
        readonly IProfileDal _profileDal;
        public ProfileManager(IProfileDal profileDal)
        {
            _profileDal = profileDal;
        }
        async public Task<IResult> AddAsync(Profile entity)
        {
            try
            {
                await _profileDal.AddAsync(entity);
            }
            catch (Exception)
            {

                return new ErrorResult();
            }
            return new SuccessResult();
        }

         public IDataResult<UserProfile> GetByEmail(string email)
        {
            UserProfile user;
            try
            {
                user = _profileDal.GetUserProfileByMail(email);

            }
            catch (Exception)
            {
                return new ErrorDataResult<UserProfile>();
            }
            return new SuccessDataResult<UserProfile>(user);
        }

        public IDataResult<UserProfile> GetByTelNo(string telNo)
        {
            UserProfile user;
            try
            {
                user = _profileDal.GetUserProfileByTelNo(telNo);

            }
            catch (Exception)
            {
                return new ErrorDataResult<UserProfile>();
            }
            return new SuccessDataResult<UserProfile>(user);
        }

        public IDataResult<UserProfile> GetByUserName(string userName)
        {
            UserProfile user;
            try
            {
                user = _profileDal.GetUserProfileByUserName(userName);

            }
            catch (Exception)
            {
                return new ErrorDataResult<UserProfile>();
            }
            return new SuccessDataResult<UserProfile>(user);
        }

        async public Task<IDataResult<List<Profile>>> GetFullUserProfilesAsync()
        {
            List<Profile> profiles;
            try
            {
                  profiles = await _profileDal.GetAllAsync();

            }
            catch (Exception)
            {

                return new ErrorDataResult<List<Profile>>();
            }
            return new SuccessDataResult<List<Profile>>();
        }

        async public Task<IResult> UpdateUserProfileAsync(Profile entity)
        {
            try
            {
                await _profileDal.UpdateAsync(entity);
            }
            catch (Exception)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
    public class AnswerManager : IAnswerService
    {
        IProfileAnswerDal _answerDal;
        public AnswerManager(IProfileAnswerDal profileAnswerDal)
        {
            _answerDal = profileAnswerDal;
        }
        async public Task<IDataResult<List<Profile_Answer>>> GetAllAsync()
        {
            List<Profile_Answer> data;
            try
            {
                data = await _answerDal.GetAllAsync();
                
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<Profile_Answer>>();
            }
            return new SuccessDataResult<List<Profile_Answer>>(data);
        }

        async public Task<IDataResult<Profile_Answer>> GetAnswerByAnswerIdAsync(int id)
        {
            Profile_Answer data;
            try
            {
                data = await _answerDal.GetAsync(p => p.AnswerId == id);
            }
            catch (Exception)
            {

                return new ErrorDataResult<Profile_Answer>();
            }
            return new SuccessDataResult<Profile_Answer>(data);
        }

        async public Task<IDataResult<List<Profile_Answer>>> GetAnswersByProfileIdAsync(int id)
        {
            List <Profile_Answer> data;
            try
            {
                data = await _answerDal.GetAllAsync(p => p.ProfileId == id);
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<Profile_Answer>>();
            }
            return new SuccessDataResult<List<Profile_Answer>>(data);
        }

        async public Task<IDataResult<List<Profile_Answer>>> GetAnswersByQuestionIdAsync(int id)
        {
            List<Profile_Answer> data;
            try
            {
                data = await _answerDal.GetAllAsync(p => p.QuestionId == id);
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<Profile_Answer>>();
            }
            return new SuccessDataResult<List<Profile_Answer>>(data);
        }
    }
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
