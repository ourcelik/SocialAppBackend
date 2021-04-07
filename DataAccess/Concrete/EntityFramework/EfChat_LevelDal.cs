using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfChat_LevelDal : EfEntityRepositoryBase<Chat_level, SocialNetworkContext>, IChatLevelDal
    {
        public SpecificChatLevel GetChatLevelByMatchId(int id)
        {
            using SocialNetworkContext context = new();
            var data = from c in context.Chat_Levels
                       join m in context.Matches
                       on c.ChatId equals m.Chat_LevelId
                       where m.MatchId == id
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
