using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IChoiceService
    {
        public Task<IDataResult<Choice>> GetByChoiceId(int id);
        public Task<IDataResult<List<Choice>>> GetAllByQuestionId(int id);
        public Task<IDataResult<List<Choice>>> GetAll();
    }
}
