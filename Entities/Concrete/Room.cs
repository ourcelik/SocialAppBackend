using Core.Entities;
using System;

namespace Entities.Concrete
{
    public class Room : IEntity
    {
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public string RoomDescription { get; set; }
        public DateTime RoomCreated { get; set; }
        public string RoomPhotoUrl { get; set; }
        public byte RoomPopularity { get; set; }
        public int MainRoomId { get; set; }

    }

}