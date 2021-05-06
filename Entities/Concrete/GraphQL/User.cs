using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.GraphQL
{
    public class User : Entities.Concrete.User,IEntity
    {

        [NotMapped]
        public Bank Bank { get; set; }

    }
}
