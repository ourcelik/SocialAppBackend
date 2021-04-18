using Core.Entities;

namespace Entities.Concrete
{
    public class ChatLevel : IEntity
    {
        public byte ChatLevelId { get; set; }
        public string Level { get; set; }
    }

}