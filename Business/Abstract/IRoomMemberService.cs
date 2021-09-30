using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Entities.DTOs.OutputDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRoomMemberService
    {
        public Task<IDataResult<List<RoomMember>>> GetMembersByRankAsync(int rankId);
        public Task<IDataResult<List<RoomMember>>> GetMembersByRoomIdAsync(int roomId);
        public Task<IDataResult<int>> SubscribeUserToRoomAsync(RoomMember roomMember);
        public Task<IDataResult<int>> UnSubscribeUserToRoom(UnSubcribeRoomMemberDto unSubcribeRoomMemberDto);
        public Task<IDataResult<IsAlreadySubscribedToRoomDto>> IsAlreadySubscribed(IsSubscribedRoomMemberDto isSubscribedRoomMemberDto);
    }
}
