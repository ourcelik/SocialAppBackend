using Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Concrete.GraphQL
{
    public class Notification : Entities.Concrete.Notification, IEntity
    {
        [NotMapped]
        public Profile Profile { get; set; }
    }

}