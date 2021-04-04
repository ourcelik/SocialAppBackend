using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAnswerService
    {
        public  Task<IDataResult<List<Profile_Answer>>> GetAllAsync();
        public  Task<IDataResult<List<Profile_Answer>>> GetAnswersByProfileIdAsync(int id);
        public  Task<IDataResult<Profile_Answer>> GetAnswerByAnswerIdAsync(int id);
        public  Task<IDataResult<List<Profile_Answer>>> GetAnswersByQuestionIdAsync(int id);
    }
}
