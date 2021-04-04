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
}
