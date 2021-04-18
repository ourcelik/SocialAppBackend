using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfChatLevelDal : EfEntityRepositoryBase<ChatLevel, SocialNetworkContext>, IChatLevelDal
    {
        public SpecificChatLevel GetChatLevelByMatchId(int id)
        {
            using SocialNetworkContext context = new();
            var data = from c in context.ChatLevels
                       join m in context.Matches
                       on c.ChatLevelId equals m.ChatLevelId
                       where m.ChatLevelId == id
                       select new SpecificChatLevel
                       {
                           Level = c.Level,
                           MatchedUser = m.MatchUserId,
                           MatchUser = m.MatchUserId,

                       };
            return data.SingleOrDefault();

        }
    }
}
