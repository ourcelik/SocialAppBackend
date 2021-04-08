using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IConstantRoomMemberService
    {
        public Task<IDataResult<List<CR_Member>>> GetMembersByRank(int rankId);
        public Task<IDataResult<List<CR_Member>>> GetMembersByRoomId(int roomId);
        
    }
}
