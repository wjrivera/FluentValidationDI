using System;
using FluentValidation;
using FluentValidationDI.Models;

namespace FluentValidationDI.Validation 
{
    public class PersonValidator : AbstractValidator<PersonModel>
    {
        public PersonValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull()
                .WithMessage("ID must not be empty, please add an ID");
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Name must not be empty, please add a name");
            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .WithMessage("Email must not be empty, please add an email")
                .EmailAddress()
                .WithMessage("A valid email is required");
            RuleFor(x => x.Active)
                .NotEmpty()
                .NotNull()
                .Equal(true)
                .WithMessage("Active must be set true");
        }
    }
}
