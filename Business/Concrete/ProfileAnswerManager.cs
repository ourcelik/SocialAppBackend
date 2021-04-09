using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProfileAnswerManager : IProfileAnswerService
    {
        readonly IProfileAnswerDal _profileAnswerDal;
        public ProfileAnswerManager(IProfileAnswerDal profileAnswerDal)
        {
            _profileAnswerDal = profileAnswerDal;
        }
        async public Task<IDataResult<List<ProfileAnswer>>> GetAllBelongsToQuestionId(int questionId)
        {
            var data = await _profileAnswerDal.GetAllAsync(pa => pa.QuestionId == questionId);
            return new SuccessDataResult<List<ProfileAnswer>>(data);
            
        }

        async public Task<IDataResult<List<ProfileAnswer>>> GetAllByAnswerId(int answerId)
        {
            var data = await _profileAnswerDal.GetAllAsync(pa => pa.AnswerId == answerId);
            return new SuccessDataResult<List<ProfileAnswer>>(data);
        }

        async public Task<IDataResult<ProfileAnswer>> GetById(int id)
        {
            var data = await _profileAnswerDal.GetAsync(pa => pa.ProfileAnswerId == id);
            return new SuccessDataResult<ProfileAnswer>(data);
        }

        async public Task<IDataResult<List<ProfileAnswer>>> GetProfileAnswerByProfileId(int profileId)
        {
            var data = await _profileAnswerDal.GetAllAsync(pa => pa.ProfileId == profileId);
            return new SuccessDataResult<List<ProfileAnswer>>(data);
        }
    }
}
