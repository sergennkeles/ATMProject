using ATMProject.Application.CQRS.Commands;
using ATMProject.Application.CQRS.Commands.Auths;
using ATMProject.Application.DTOs;
using ATMProject.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject.Application.Validators
{
    public class CreateUserValidator: AbstractValidator<RegisterCommand>
    {
        public CreateUserValidator()
        {
            RuleFor(x=>x.RegisterDto.FirstName).NotEmpty().NotNull().WithMessage("{PropertyName} is required" );
            RuleFor(x=>x.RegisterDto.LastName).NotEmpty().NotNull().WithMessage("{PropertyName} is required" );
            RuleFor(x=>x.RegisterDto.Email).NotEmpty().NotNull().EmailAddress().WithMessage("{PropertyName} is required" );
            RuleFor(x=>x.RegisterDto.Password).NotEmpty().NotNull().WithMessage("{PropertyName} is required" );
        }
    }
}
