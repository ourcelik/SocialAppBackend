using Business.Abstract;
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
    class LikeKindManager : ILikeKindService
    {
        ILikeKindDal _likeKindDal;
        public LikeKindManager(ILikeKindDal likeKindDal)
        {
            _likeKindDal = likeKindDal;
        }
        async public Task<IDataResult<List<Like_Kind>>> GetLikeKinds()
        {
            var data = await _likeKindDal.GetAllAsync();
            return new SuccessDataResult<List<Like_Kind>>(data);
        }
    }
}
