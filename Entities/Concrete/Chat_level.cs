using Core.Entities;

namespace Entities.Concrete
{
    public class Chat_level : IEntity
    {
        public int ChatId { get; set; }
        public string Level { get; set; }
    }

}