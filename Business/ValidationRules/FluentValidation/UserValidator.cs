﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            throw new System.Exception();
        }
    }
}
