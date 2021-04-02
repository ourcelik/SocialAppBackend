using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IChoiceService
    {
        public IDataResult<List<Choice>> GetChoicesByChoiceId();
        public IDataResult<List<Choice>> GetChoicesByQuestionId();
    }
}
