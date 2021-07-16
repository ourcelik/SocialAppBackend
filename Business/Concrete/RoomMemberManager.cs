using Business.Abstract;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RoomMemberManager : IRoomMemberService
    {
        readonly IRMemberDal _rMemberDal;

        public RoomMemberManager(IRMemberDal rMemberDal)
        {
            _rMemberDal = rMemberDal;
        }

        async public Task<IDataResult<List<RoomMember>>> GetMembersByRankAsync(int rankId)
        {
            var data = await _rMemberDal.GetAllAsync(rm => rm.RankId == rankId);

            return new ErrorDataResult<List<RoomMember>>(data);
        }

        async public Task<IDataResult<List<RoomMember>>> GetMembersByRoomIdAsync(int roomId)
        {
            var data = await _rMemberDal.GetAllAsync(cr => cr.RoomId == roomId);

            return new ErrorDataResult<List<RoomMember>>(data);
        }
    }
}
