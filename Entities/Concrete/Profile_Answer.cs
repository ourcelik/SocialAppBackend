﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Profile_Answer:IEntity
    {
        public int AnswerId { get; set; }
        public int ProfileId { get; set; }
        public int QuestionId { get; set; }
    }
}