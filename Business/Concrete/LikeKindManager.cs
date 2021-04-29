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
    public class LikeKindManager : ILikeKindService
    {
        readonly ILikeKindDal _likeKindDal;
        public LikeKindManager(ILikeKindDal likeKindDal)
        {
            _likeKindDal = likeKindDal;
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        async public Task<IDataResult<List<LikeKind>>> GetAllKindsAsync()
        {
            var data = await _likeKindDal.GetAllAsync();
            return new SuccessDataResult<List<LikeKind>>(data);
        }
    }
}
