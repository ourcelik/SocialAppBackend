using Core.DataAccess;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IChatLevelDal:IEntityRepository<ChatLevel>
    {
        public SpecificChatLevel GetChatLevelByMatchId(int id);
    }
    
}
