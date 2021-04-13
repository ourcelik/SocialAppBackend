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
    public class ConstantRoomManager : IConstantRoomService
    {
        readonly IConstantRoomDal _roomDal;
        public ConstantRoomManager(IConstantRoomDal roomDal)
        {
            _roomDal = roomDal;
        }
        async public Task<IDataResult<List<ConstantRoom>>> GetAllConstantRoom()
        {
            var data = await _roomDal.GetAllAsync();
            return new SuccessDataResult<List<ConstantRoom>>(data);
        }

        async public Task<IDataResult<List<ConstantRoom>>> GetByChatLevel(int id)
        {
            var data = await _roomDal.GetAllAsync(r => r.ChatLevelId == id);
            return new SuccessDataResult<List<ConstantRoom>>(data);
        }

        async public Task<IDataResult<ConstantRoom>> GetByConstantRoomId(int id)
        {
            var data = await _roomDal.GetAsync(r => r.RoomId == id);
            return new SuccessDataResult<ConstantRoom>(data);
        }
    }
}
