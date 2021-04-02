using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IAnswerService
    {
        public IDataResult<List<Profile_Answer>> GetAll();
        public IDataResult<List<Profile_Answer>> GetAnswersByProfileId(int id);
        public IDataResult<Profile_Answer> GetAnswerByAnswerId(int id);
        public IDataResult<List<Profile_Answer>> GetAnswersByQuestionId(int id);
    }
}
