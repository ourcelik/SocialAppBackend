using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IConstantRoomMemberService
    {
        public IDataResult<List<CR_Member>> GetMembersByRoomId();
        public IDataResult<CR_Member> GetMemberByUserId();
        public IDataResult<List<CR_Member>> GetMembersByRank();
    }
}
