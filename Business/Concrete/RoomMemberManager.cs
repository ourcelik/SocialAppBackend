using Business.Abstract;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Entities.DTOs.OutputDtos;
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

            return new SuccessDataResult<List<RoomMember>>(data);
        }

        async public Task<IDataResult<List<RoomMember>>> GetMembersByRoomIdAsync(int roomId)
        {
            var data = await _rMemberDal.GetAllAsync(cr => cr.RoomId == roomId);

            return new SuccessDataResult<List<RoomMember>>(data);
        }

        [FillUserIdAspect(parameterIndex: 0, propName: "UserId")]
        public async Task<IDataResult<IsAlreadySubscribedToRoomDto>> IsAlreadySubscribed(IsSubscribedRoomMemberDto isSubscribedRoomMemberDto)
        {
            RoomMember unSubscribeMemberModel = await _rMemberDal.GetAsync(rm => rm.RoomId == isSubscribedRoomMemberDto.RoomId && rm.UserId == isSubscribedRoomMemberDto.UserId);
            
            return unSubscribeMemberModel != null ? new SuccessDataResult<IsAlreadySubscribedToRoomDto>(new IsAlreadySubscribedToRoomDto() {IsSubscribed = true })
                                                    : new SuccessDataResult<IsAlreadySubscribedToRoomDto>(new IsAlreadySubscribedToRoomDto() { IsSubscribed = false });
        }

        [FillUserIdAspect(parameterIndex: 0,propName:"UserId")]
        public async Task<IDataResult<int>> SubscribeUserToRoomAsync(RoomMember roomMember)
        {
            var userIsAlreadySubscribed = await IsAlreadySubscribed(new IsSubscribedRoomMemberDto() { RoomId = roomMember.RoomId, UserId = roomMember.UserId });

            if(userIsAlreadySubscribed.Data.IsSubscribed)
            {
                return new ErrorDataResult<int>(0,"Zaten bu kanala Abonesiniz.");
            }

            var data = await _rMemberDal.AddAsync(roomMember);

            return new SuccessDataResult<int>(data.RoomMemberId);
        }

        [FillUserIdAspect(parameterIndex: 0, propName: "UserId")]
        public async Task<IDataResult<int>> UnSubscribeUserToRoom(UnSubcribeRoomMemberDto unSubcribeRoomMemberDto)
        {
            RoomMember unSubscribeMemberModel = await _rMemberDal.GetAsync(rm => rm.RoomId == unSubcribeRoomMemberDto.RoomId && rm.UserId == unSubcribeRoomMemberDto.UserId);

            await _rMemberDal.DeleteAsync(unSubscribeMemberModel);

            return new SuccessDataResult<int>(0);
        }
    }
}
