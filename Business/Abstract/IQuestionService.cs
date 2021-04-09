using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IQuestionService
    {
        public Task<IDataResult<Question>> GetQuestionByQuestionId(int id);
        public Task<IDataResult<List<Question>>> GetAllQuestions();
    }
}
