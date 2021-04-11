using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    interface IProfileQuestionService
    {
        public Task<IDataResult<List<ProfileQuestion>>> GetAllByProfileId(int profileId);
        public Task<IDataResult<List<ProfileQuestion>>> GetAll();
        public Task<IDataResult<List<ProfileQuestion>>> GetAllByQuestionId(int questionId);
        public Task<IDataResult<List<ProfileQuestion>>> GetAllByChoiceId(int choiceId);
        public Task<IDataResult<ProfileQuestion>> GetById(int id);




    }
}
