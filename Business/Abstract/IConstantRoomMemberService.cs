using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IConstantRoomMemberService
    {
        public Task<IDataResult<List<ConstantRoomMember>>> GetMembersByRank(int rankId);
        public Task<IDataResult<List<ConstantRoomMember>>> GetMembersByRoomId(int roomId);
        
    }
}
