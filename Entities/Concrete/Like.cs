using Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Like : IEntity
    {
        [Key]
        public int LikeId { get; set; }
        public int ReceiverId { get; set; }
        public int SenderId { get; set; }
        public byte KindId { get; set; }

    }

}