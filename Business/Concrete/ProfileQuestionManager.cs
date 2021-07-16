using Business.Abstract;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    class ProfileQuestionManager : IProfileQuestionService
    {
        readonly IProfileQuestionDal _profileQuestionDal;
        public ProfileQuestionManager(IProfileQuestionDal profileQuestionDal)
        {
            _profileQuestionDal = profileQuestionDal;
        }

        async public Task<IDataResult<List<ProfileQuestion>>> GetAllAsync()
        {
            var data = await _profileQuestionDal.GetAllAsync();

            return new SuccessDataResult<List<ProfileQuestion>>(data);
        }

        async public Task<IDataResult<List<ProfileQuestion>>> GetAllByChoiceIdAsync(int choiceId)
        {
            var data = await _profileQuestionDal.GetAllAsync(pq=> pq.ChoiceId == choiceId);

            return new SuccessDataResult<List<ProfileQuestion>>(data);
        }

        async public Task<IDataResult<List<ProfileQuestion>>> GetAllByProfileIdAsync(int profileId)
        {
            var data = await _profileQuestionDal.GetAllAsync(pq => pq.ProfileId == profileId);

            return new SuccessDataResult<List<ProfileQuestion>>(data);
        }

        async public Task<IDataResult<List<ProfileQuestion>>> GetAllByQuestionIdAsync(int questionId)
        {
            var data = await _profileQuestionDal.GetAllAsync(pq => pq.QuestionId == questionId);

            return new SuccessDataResult<List<ProfileQuestion>>(data);
        }

        async public Task<IDataResult<ProfileQuestion>> GetByIdAsync(int id)
        {
            var data = await _profileQuestionDal.GetAsync(pq => pq.ProfileId == id);

            return new SuccessDataResult<ProfileQuestion>(data);
        }
    }
}
