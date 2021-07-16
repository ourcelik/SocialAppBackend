using Core.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class ConstantRoom : IEntity
    {
        [Key]
        public int RoomId { get; set; }
        public byte ChatLevelId { get; set; }
        public string RoomName { get; set; }
        public string RoomDescription { get; set; }
        public DateTime RoomCreated { get; set; }
        public string RoomPhotoUrl { get; set; }
        public byte RoomPopularity { get; set; }

    }

}