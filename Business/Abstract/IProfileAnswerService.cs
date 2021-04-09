using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    interface IProfileAnswerService
    {
        public Task<IDataResult<List<ProfileAnswer>>> GetProfileAnswerByProfileId(int profileId);
        public Task<IDataResult<List<ProfileAnswer>>> GetAllBelongsToQuestionId(int questionId);
        public Task<IDataResult<List<ProfileAnswer>>> GetAllByAnswerId(int answerId);
        public Task<IDataResult<ProfileAnswer>> GetById(int id);


    }
}
