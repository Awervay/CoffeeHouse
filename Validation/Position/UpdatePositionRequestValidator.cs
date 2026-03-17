using FluentValidation;
using Contract.Staff.Models.Position;

namespace Validation.Position;

public class UpdatePositionRequestValidator : AbstractValidator<UpdatePositionRequest>
{
    public UpdatePositionRequestValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required")
            .MaximumLength(100);
    }
}
