using Business.Abstract;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Exception;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Performance;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
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


        async public Task<IDataResult<List<Choice>>> GetAll()
        {
            var data = await _choiceDal.GetAllAsync();
            
            return new SuccessDataResult<List<Choice>>(data);
        }

        async public Task<IDataResult<Choice>> GetByChoiceId(int id)
        {
            var    data = await _choiceDal.GetAsync(c => c.ChoiceId == id);
            
            return new SuccessDataResult<Choice>(data);
        }

        async public Task<IDataResult<List<Choice>>> GetAllByQuestionId(int id)
        {
            var    data = await _choiceDal.GetAllAsync(c => c.QuestionId == id);
            
            return new SuccessDataResult<List<Choice>>(data);
        }
    }
}
