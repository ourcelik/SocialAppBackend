using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IChatLevelService
    {
        public IDataResult<SpecificChatLevel> GetChatLevelByMatch(int id);
        public Task<IDataResult<List<Chat_level>>> GetAll();
        public Task<IDataResult<Chat_level>> GetByChatLevelId(int id);
        public Task<IDataResult<List<Chat_level>>> GetByChatLevel(string level);




    }
}
