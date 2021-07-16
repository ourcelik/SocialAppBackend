using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RoomManager : IRoomService
    {
        IRoomDal _roomDal;

        public RoomManager(IRoomDal roomDal)
        {
            _roomDal = roomDal;
        }

        async public Task<IDataResult<List<Room>>> GetAllAsync()
        {
            var data = await _roomDal.GetAllAsync();

            return new SuccessDataResult<List<Room>>(data);
        }

        async public Task<IDataResult<Room>> GetRoomByIdAsync(int id)
        {
            var data = await _roomDal.GetAsync(r=> r.RoomId == id);
            
            return new SuccessDataResult<Room>(data);
        }
        async public Task<IDataResult<List<Room>>> GetRoomByMainRoomIdAsync(int id)
        {
            var data = await _roomDal.GetAllAsync(r => r.MainRoomId == id);

            return new SuccessDataResult<List<Room>>(data);
        }





    }
}
