using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IRoomService
    {
        public IDataResult<List<Room>> GetAll();
        public IDataResult<List<Room>> GetRoomsByLevelId(int id);
        public IDataResult<List<Room>> GetRoomsByAdminId(int id);



    }
}
