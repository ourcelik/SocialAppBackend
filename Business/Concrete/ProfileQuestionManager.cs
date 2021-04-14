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

        [CacheAspect]
        [PerformanceAspect(5)]
        async public Task<IDataResult<List<ProfileQuestion>>> GetAll()
        {
            var data = await _profileQuestionDal.GetAllAsync();
            return new SuccessDataResult<List<ProfileQuestion>>(data);
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        async public Task<IDataResult<List<ProfileQuestion>>> GetAllByChoiceId(int choiceId)
        {
            var data = await _profileQuestionDal.GetAllAsync(pq=> pq.ChoiceId == choiceId);
            return new SuccessDataResult<List<ProfileQuestion>>(data);
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        async public Task<IDataResult<List<ProfileQuestion>>> GetAllByProfileId(int profileId)
        {
            var data = await _profileQuestionDal.GetAllAsync(pq => pq.ProfileId == profileId);
            return new SuccessDataResult<List<ProfileQuestion>>(data);
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        async public Task<IDataResult<List<ProfileQuestion>>> GetAllByQuestionId(int questionId)
        {
            var data = await _profileQuestionDal.GetAllAsync(pq => pq.QuestionId == questionId);
            return new SuccessDataResult<List<ProfileQuestion>>(data);
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        async public Task<IDataResult<ProfileQuestion>> GetById(int id)
        {
            var data = await _profileQuestionDal.GetAsync(pq => pq.ProfileQuestionId == id);
            return new SuccessDataResult<ProfileQuestion>(data);
        }
    }
}
