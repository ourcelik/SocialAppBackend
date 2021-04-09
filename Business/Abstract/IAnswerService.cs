using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAnswerService
    {
        public  Task<IDataResult<List<ProfileAnswer>>> GetAllAsync();
        public  Task<IDataResult<List<ProfileAnswer>>> GetAnswersByProfileIdAsync(int id);
        public  Task<IDataResult<ProfileAnswer>> GetAnswerByAnswerIdAsync(int id);
        public  Task<IDataResult<List<ProfileAnswer>>> GetAnswersByQuestionIdAsync(int id);
    }
}
