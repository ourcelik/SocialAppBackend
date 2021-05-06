using Core.Entities;

namespace Entities.Concrete
{
    public class Match : IEntity
    {
        public int MatchId { get; set; }
        public int MatchProfileId { get; set; }
        public int MatchedProfileId { get; set; }
        public byte ChatLevelId { get; set; }
    }

}