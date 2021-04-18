using Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class ConstantRoom : IEntity
    {
        [Key]
        public int RoomId { get; set; }
        public byte ChatLevelId { get; set; }
    }

}