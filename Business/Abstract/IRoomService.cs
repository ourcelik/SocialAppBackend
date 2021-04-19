using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRoomService
    {
         public Task<IDataResult<List<Room>>> GetAllAsync();
         public Task<IDataResult<List<Room>>> GetRoomsByLevelIdAsync(int levelId);
         public Task<IDataResult<Room>> GetRoomByIdAsync(int id);



    }
}
