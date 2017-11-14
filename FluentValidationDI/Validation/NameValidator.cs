using FluentValidation;
using FluentValidationDI.Models;

namespace FluentValidationDI.Validation
{
    public class NameValidator : AbstractValidator<PersonModel>
    {
        public NameValidator()
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
