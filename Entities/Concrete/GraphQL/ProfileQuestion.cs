using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.GraphQL
{
    public class ProfileQuestion: Entities.Concrete.ProfileQuestion, IEntity
    {
        [NotMapped]
        public Profile Profile { get; set; }
        [NotMapped]
        public Question Question { get; set; }
        [NotMapped]
        public Choice Choice { get; set; }
    }
}
