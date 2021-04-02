using Core.Entities;

namespace Entities.Concrete
{
    public class Constant_room : IEntity
    {
        public int RoomId { get; set; }
        public int Chat_LevelId { get; set; }
    }

}