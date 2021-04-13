using Core.Entities;

namespace Entities.Concrete
{
    public class ChatLevel : IEntity
    {
        public int ChatLevelId { get; set; }
        public string Level { get; set; }
    }

}