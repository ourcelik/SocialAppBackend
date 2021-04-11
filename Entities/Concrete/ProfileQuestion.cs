using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class ProfileQuestion:IEntity
    {
        public int ProfileQuestionId { get; set; }
        public int ProfileId { get; set; }
        public int QuestionId { get; set; }
        public int ChoiceId { get; set; }
    }
}
