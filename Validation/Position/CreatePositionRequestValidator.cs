using FluentValidation;
using Contract.Staff.Models.Position;

namespace Validation.Position;

public class CreatePositionRequestValidator : AbstractValidator<CreatePositionRequest>
{
    public CreatePositionRequestValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required")
            .MaximumLength(100);
    }
}
