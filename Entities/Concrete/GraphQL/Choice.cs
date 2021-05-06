using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.GraphQL
{
    public class Choice:Entities.Concrete.Choice,IEntity
    {
        [NotMapped]
        public Question Question { get; set; }

    }
}
