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
    class ConstantRoomManager : IConstantRoomService
    {
        IConstantRoomDal _roomDal;
        public ConstantRoomManager(IConstantRoomDal roomDal)
        {
            _roomDal = roomDal;
        }
        async public Task<IDataResult<List<Constant_room>>> GetAllConstantRoom()
        {
            var data = await _roomDal.GetAllAsync();
            return new SuccessDataResult<List<Constant_room>>(data);
        }

        async public Task<IDataResult<List<Constant_room>>> GetByChatLevel(int id)
        {
            var data = await _roomDal.GetAllAsync(r => r.Chat_LevelId == id);
            return new SuccessDataResult<List<Constant_room>>(data);
        }

        async public Task<IDataResult<Constant_room>> GetByConstantRoomId(int id)
        {
            var data = await _roomDal.GetAsync(r => r.RoomId == id);
            return new SuccessDataResult<Constant_room>(data);
        }
    }
}
