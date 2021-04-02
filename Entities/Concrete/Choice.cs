using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Choice:IEntity
    {
        public int ChoiceId { get; set; }
        public string _Choice { get; set; }
        public int QuestionId { get; set; }
    }
}
