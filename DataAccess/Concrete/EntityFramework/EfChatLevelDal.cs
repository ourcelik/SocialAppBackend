using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfChatLevelDal : EfEntityRepositoryBase<ChatLevel, SocialNetworkContext>, IChatLevelDal
    {
        public SpecificChatLevelDto GetChatLevelByMatchId(int id)
        {
            using SocialNetworkContext context = new();
            var data = from c in context.ChatLevels
                       join m in context.Matches
                       on c.ChatLevelId equals m.ChatLevelId
                       where m.MatchId == id
                       select new SpecificChatLevelDto
                       {
                           Level = c.Level,
                           MatchedUser = m.MatchProfileId,
                           MatchUser = m.MatchedProfileId,

                       };
            return data.SingleOrDefault();

        }
    }
}
