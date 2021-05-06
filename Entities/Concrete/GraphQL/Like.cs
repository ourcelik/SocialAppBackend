using Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Concrete.GraphQL
{
    public class Like : Entities.Concrete.Like, IEntity
    {
        [NotMapped]
        public Profile Receiver { get; set; }
        [NotMapped]
        public Profile Sender { get; set; }
        [NotMapped]
        public LikeKind Kind { get; set; }

    }

}