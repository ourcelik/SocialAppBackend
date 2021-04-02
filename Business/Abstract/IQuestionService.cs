using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IQuestionService
    {
        public IDataResult<Question> GetQuestionByQuestionId(int id);
        public IDataResult<List<Question>> GetAll();
    }
}
