using Core.Entities;

namespace Entities.Concrete
{
    public class Room : IEntity
    {
        public int RoomId { get; set; }
        public int Chat_LevelId { get; set; }
    }

}