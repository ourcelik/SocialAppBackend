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
    public class ConstantRoomMemberManager : IConstantRoomMemberService
    {
        readonly ICrMemberDal _roomMemberDal;
        public ConstantRoomMemberManager(ICrMemberDal roomMemberService)
        {
            _roomMemberDal = roomMemberService;
        }

        async public Task<IDataResult<List<CR_Member>>> GetMembersByRank(int rankId)
        {
            List<CR_Member> data;
            try
            {
                data = await _roomMemberDal.GetAllAsync(cr => cr.RankId == rankId);
            }
            catch (Exception)
            {
                return new ErrorDataResult<List<CR_Member>>();
            }
            return new ErrorDataResult<List<CR_Member>>(data);
        }

        async public Task<IDataResult<List<CR_Member>>> GetMembersByRoomId(int roomId)
        {
            List<CR_Member> data;
            try
            {
                data = await _roomMemberDal.GetAllAsync(cr => cr.C_RoomId == roomId);
            }
            catch (Exception)
            {
                return new ErrorDataResult<List<CR_Member>>();
            }
            return new ErrorDataResult<List<CR_Member>>(data);
        }
    }
}
