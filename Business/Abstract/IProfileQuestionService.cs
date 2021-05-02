using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProfileQuestionService
    {
        public Task<IDataResult<List<ProfileQuestion>>> GetAllByProfileIdAsync(int profileId);
        public Task<IDataResult<List<ProfileQuestion>>> GetAllAsync();
        public Task<IDataResult<List<ProfileQuestion>>> GetAllByQuestionIdAsync(int questionId);
        public Task<IDataResult<List<ProfileQuestion>>> GetAllByChoiceIdAsync(int choiceId);
        public Task<IDataResult<ProfileQuestion>> GetByIdAsync(int id);




    }
}
