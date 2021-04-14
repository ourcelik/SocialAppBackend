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
    public class ConstantRoomMemberManager : IConstantRoomMemberService
    {
        readonly ICrMemberDal _roomMemberDal;
        public ConstantRoomMemberManager(ICrMemberDal roomMemberService)
        {
            _roomMemberDal = roomMemberService;
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        async public Task<IDataResult<List<ConstantRoomMember>>> GetMembersByRank(int rankId)
        {
            List<ConstantRoomMember> data;
            try
            {
                data = await _roomMemberDal.GetAllAsync(cr => cr.RankId == rankId);
            }
            catch (Exception)
            {
                return new ErrorDataResult<List<ConstantRoomMember>>();
            }
            return new ErrorDataResult<List<ConstantRoomMember>>(data);
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        async public Task<IDataResult<List<ConstantRoomMember>>> GetMembersByRoomId(int roomId)
        {
            List<ConstantRoomMember> data;
            try
            {
                data = await _roomMemberDal.GetAllAsync(cr => cr.ConstantRoomId == roomId);
            }
            catch (Exception)
            {
                return new ErrorDataResult<List<ConstantRoomMember>>();
            }
            return new ErrorDataResult<List<ConstantRoomMember>>(data);
        }
    }
}
