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
    class RankManager : IRankService
    {
        readonly IRankDal _rankDal;
        public RankManager(IRankDal rankDal)
        {
            _rankDal = rankDal;
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        async public Task<IDataResult<List<Rank>>> GetAll()
        {
            var data = await _rankDal.GetAllAsync();
            return new SuccessDataResult<List<Rank>>(data);
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        async public Task<IDataResult<Rank>> GetByRankId(int id)
        {
            var data = await _rankDal.GetAsync(r=> r.RankId == id);
            return new SuccessDataResult<Rank>(data);
        }
    }
}
