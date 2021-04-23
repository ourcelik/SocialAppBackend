using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IChatLevelService
    {
        public IDataResult<SpecificChatLevelDto> GetChatLevelByMatch(int id);
        public Task<IDataResult<List<ChatLevel>>> GetAll();
        public Task<IDataResult<ChatLevel>> GetByChatLevelId(int id);
        public Task<IDataResult<List<ChatLevel>>> GetByChatLevel(string level);




    }
}
