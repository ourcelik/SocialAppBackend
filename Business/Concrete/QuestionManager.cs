using Business.Abstract;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class QuestionManager : IQuestionService
    {
        IQuestionDal _questionDal;

        public QuestionManager(IQuestionDal questionDal)
        {
            _questionDal = questionDal;
        }

        [CacheAspect]
        async public Task<IDataResult<List<Question>>> GetAllQuestions()
        {
            var data = await _questionDal.GetAllAsync();

            return new SuccessDataResult<List<Question>>(data);
        }

        async public Task<IDataResult<Question>> GetQuestionByQuestionId(int id)
        {
            var data = await _questionDal.GetAsync(q => q.QuestionId == id);
            
            return new SuccessDataResult<Question>(data);
        }
    }
}
