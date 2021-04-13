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
        readonly IRankDal _answerDal;

        public AnswerManager(IRankDal answerDal)
        {
            _answerDal = answerDal;
        }

        async public Task<IDataResult<List<Rank>>> GetAllAsync()
        {
            List<Rank> data;
            try
            {
                data = await _answerDal.GetAllAsync();
                
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<Rank>>();
            }
            return new SuccessDataResult<List<Rank>>(data);
        }

        async public Task<IDataResult<Rank>> GetAnswerByAnswerIdAsync(int id)
        {
            Rank data;
            try
            {
                data = await _answerDal.GetAsync(p => p.AnswerId == id);
            }
            catch (Exception)
            {

                return new ErrorDataResult<Rank>();
            }
            return new SuccessDataResult<Rank>(data);
        }

        async public Task<IDataResult<List<Rank>>> GetAnswersByProfileIdAsync(int id)
        {
            List <Rank> data;
            try
            {
                data = await _answerDal.GetAllAsync(p => p.ProfileId == id);
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<Rank>>();
            }
            return new SuccessDataResult<List<Rank>>(data);
        }

        async public Task<IDataResult<List<Rank>>> GetAnswersByQuestionIdAsync(int id)
        {
            List<Rank> data;
            try
            {
                data = await _answerDal.GetAllAsync(p => p.QuestionId == id);
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<Rank>>();
            }
            return new SuccessDataResult<List<Rank>>(data);
        }
    }
}
