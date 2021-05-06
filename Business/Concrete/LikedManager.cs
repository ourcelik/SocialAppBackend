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
    public class LikedManager : ILikedService
    {
        readonly ILikedDal _likedDal;
        public LikedManager(ILikedDal likedDal)
        {
            _likedDal = likedDal;
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        async public Task<IDataResult<List<Like>>> GetAllAsync()
        {
            var data = await _likedDal.GetAllAsync();
            return new SuccessDataResult<List<Like>>(data);
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        async public Task<IDataResult<List<Like>>> GetAllByKindIdAsync(int kindId)
        {
            var data = await _likedDal.GetAllAsync(l => l.KindId == kindId);
            return new SuccessDataResult<List<Like>>(data);
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        async public Task<IDataResult<List<Like>>> GetAllByReceiverIdAsync(int receiverId)
        {
            var data = await _likedDal.GetAllAsync(l => l.ReceiverId == receiverId);
            return new SuccessDataResult<List<Like>>(data);
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        async public Task<IDataResult<List<Like>>> GetAllBySenderIdAsync(int senderId)
        {
            var data = await _likedDal.GetAllAsync(l=> l.SenderId == senderId);
            return new SuccessDataResult<List<Like>>(data);
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        async public Task<IDataResult<Like>> GetByIdAsync(int id)
        {
            var data = await _likedDal.GetAsync(l=> l.KindId == id);
            return new SuccessDataResult<Like>(data);
        }
    }
}
