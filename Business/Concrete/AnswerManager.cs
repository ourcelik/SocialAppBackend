using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AnswerManager : IAnswerService
    {
        readonly IProfileAnswerDal _answerDal;
        public AnswerManager(IProfileAnswerDal profileAnswerDal)
        {
            _answerDal = profileAnswerDal;
        }
        async public Task<IDataResult<List<ProfileAnswer>>> GetAllAsync()
        {
            List<ProfileAnswer> data;
            try
            {
                data = await _answerDal.GetAllAsync();
                
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<ProfileAnswer>>();
            }
            return new SuccessDataResult<List<ProfileAnswer>>(data);
        }

        async public Task<IDataResult<ProfileAnswer>> GetAnswerByAnswerIdAsync(int id)
        {
            ProfileAnswer data;
            try
            {
                data = await _answerDal.GetAsync(p => p.AnswerId == id);
            }
            catch (Exception)
            {

                return new ErrorDataResult<ProfileAnswer>();
            }
            return new SuccessDataResult<ProfileAnswer>(data);
        }

        async public Task<IDataResult<List<ProfileAnswer>>> GetAnswersByProfileIdAsync(int id)
        {
            List <ProfileAnswer> data;
            try
            {
                data = await _answerDal.GetAllAsync(p => p.ProfileId == id);
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<ProfileAnswer>>();
            }
            return new SuccessDataResult<List<ProfileAnswer>>(data);
        }

        async public Task<IDataResult<List<ProfileAnswer>>> GetAnswersByQuestionIdAsync(int id)
        {
            List<ProfileAnswer> data;
            try
            {
                data = await _answerDal.GetAllAsync(p => p.QuestionId == id);
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<ProfileAnswer>>();
            }
            return new SuccessDataResult<List<ProfileAnswer>>(data);
        }
    }
}
