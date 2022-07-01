using ATMProject.Application.CQRS.Commands.Customers;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject.Application.Validators
{
  
    public class UpdateUserValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().NotNull().WithMessage("{PropertyName} is required");
            RuleFor(x => x.LastName).NotEmpty().NotNull().WithMessage("{PropertyName} is required");
            RuleFor(x => x.Email).NotEmpty().NotNull().EmailAddress().WithMessage("{PropertyName} is required");
            RuleFor(x => x.Password).NotEmpty().NotNull().WithMessage("{PropertyName} is required");
        }
    }
}
