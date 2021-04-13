using Core.Entities;

namespace Entities.Concrete
{
    public class Match : IEntity
    {
        public int MatchId { get; set; }
        public int MatchUserId { get; set; }
        public int MatchedUserId { get; set; }
        public int ChatLevelId { get; set; }
    }

}