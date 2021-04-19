using Core.Entities;

namespace Entities.Concrete
{
    public class Room : IEntity
    {
        public int RoomId { get; set; }
        public byte ChatLevelId { get; set; }
    }

}