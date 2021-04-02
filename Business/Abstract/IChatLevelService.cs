using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IChatLevelService
    {
        public IDataResult<Chat_level> GetChatLevelByMatch();
    }
}
