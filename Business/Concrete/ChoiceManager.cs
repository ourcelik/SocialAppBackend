using Business.Abstract;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
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
    public class ChoiceManager : IChoiceService
    {
        readonly IChoiceDal _choiceDal;
        public ChoiceManager(IChoiceDal choiceDal)
        {
            _choiceDal = choiceDal;
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        async public Task<IDataResult<List<Choice>>> GetAll()
        {
            List<Choice> data;
            try
            {
                data = await _choiceDal.GetAllAsync();
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<Choice>>();
            }
            return new SuccessDataResult<List<Choice>>(data);
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        async public Task<IDataResult<Choice>> GetByChoiceId(int id)
        {
            Choice data;
            try
            {
                data = await _choiceDal.GetAsync(c => c.ChoiceId == id);
            }
            catch (Exception)
            {

                return new ErrorDataResult<Choice>();
            }
            return new SuccessDataResult<Choice>(data);
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        async public Task<IDataResult<List<Choice>>> GetAllByQuestionId(int id)
        {
            List<Choice> data;
            try
            {
                data = await _choiceDal.GetAllAsync(c => c.QuestionId == id);
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<Choice>>();
            }
            return new SuccessDataResult<List<Choice>>(data);
        }
    }
}
