using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IConstantRoomService
    {
        public Task<IDataResult<List<ConstantRoom>>> GetByChatLevel(int id);
        public Task<IDataResult<List<ConstantRoom>>> GetAllConstantRoom();
        public Task<IDataResult<ConstantRoom>> GetByConstantRoomId(int id);

    }
}
