using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IConstantRoomService
    {
        public Task<IDataResult<List<Constant_room>>> GetByChatLevel(int id);
        public Task<IDataResult<List<Constant_room>>> GetAllConstantRoom();
        public Task<IDataResult<Constant_room>> GetByConstantRoomId(int id);

    }
}
