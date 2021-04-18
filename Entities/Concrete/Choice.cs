using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Choice:IEntity
    {
        [Key]
        public int ChoiceId { get; set; }
        public string ChoiceType { get; set; }
        public int QuestionId { get; set; }
    }
}
