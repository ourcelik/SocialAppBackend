using Core.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Concrete.GraphQL
{
    public class Question : Entities.Concrete.Question, IEntity
    {
        [NotMapped]
        public List<Choice> Choices { get; set; }
    }

}