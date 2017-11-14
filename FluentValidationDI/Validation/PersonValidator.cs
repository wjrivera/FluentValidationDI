using System;
using FluentValidation;
using FluentValidationDI.Models;

namespace FluentValidationDI.Validation 
{
    public class PersonValidator : AbstractValidator<PersonModel>
    {
        public PersonValidator()
        {
            RuleSet("common", () =>
            {
                RuleFor(x => x.Id)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("ID must not be empty, please add an ID property");
                ExecuteCommonRules();
            });

            RuleSet("uncommon", () =>
            {
                RuleFor(x => x.Id)
                    .LessThan(4)
                    .WithMessage("ID must not be empty, please add an ID property");
                ExecuteCommonRules();
            });
        }

        private void ExecuteCommonRules()
        {
            RuleFor(x => x)
                .SetValidator(new XNameValidator())
                .OverridePropertyName("common")
                .WithName("common");
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
    public class XNameValidator : AbstractValidator<PersonModel>
    {
        public XNameValidator()
        {
            RuleSet("common", () =>
            {
                RuleFor(x => x.Name)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("Name must not be empty, please add a name")
                    .Length(1, 20)
                    .WithMessage("Name must be between 1 and 20 characters");
            });
        }
    }
}
