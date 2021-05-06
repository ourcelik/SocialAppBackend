using Core.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Concrete.GraphQL
{
    public class Prefer : Entities.Concrete.Prefer, IEntity
    {
        [NotMapped]
        public Profile Profile { get; set; }

    }

}