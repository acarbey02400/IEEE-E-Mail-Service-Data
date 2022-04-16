using Core.Entity.Concrete;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(p => p.eMail).NotEmpty();
            RuleFor(p => p.userName).NotEmpty();
            RuleFor(p => p.userName).MinimumLength(2);
            RuleFor(p => p.password).NotEmpty();
            RuleFor(p => p.password).MinimumLength(3);
            RuleFor(p => p.firstName).NotEmpty();
            RuleFor(p => p.eMail).EmailAddress();
        }
    }
}
