using Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Concrete.GraphQL
{
    public class Photo : Entities.Concrete.Photo, IEntity
    {
        [NotMapped]
        public Profile Profile { get; set; }
    }

}