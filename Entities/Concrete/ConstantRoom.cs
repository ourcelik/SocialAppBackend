using Core.Entities;

namespace Entities.Concrete
{
    public class ConstantRoom : IEntity
    {
        public int RoomId { get; set; }
        public int ChatLevelId { get; set; }
    }

}