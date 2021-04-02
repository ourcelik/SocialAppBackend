using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IConstantRoomService
    {
        public IDataResult<List<Constant_room>> GetConstantRooms();
        public IDataResult<List<Constant_room>> GetConstantRoomsByChatLevel();
        public IDataResult<Constant_room> GetRoomByRoomId();
    }
}
