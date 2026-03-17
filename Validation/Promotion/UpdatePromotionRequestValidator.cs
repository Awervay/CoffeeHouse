using FluentValidation;
using Contract.Stocks.Models.Promotion;

namespace Validation.Promotion;

public class UpdatePromotionRequestValidator : AbstractValidator<UpdatePromotionRequest>
{
    public UpdatePromotionRequestValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required")
            .MaximumLength(150);

        RuleFor(x => x.Description)
            .MaximumLength(500)
            .WithMessage("Description cannot exceed 500 characters");

        RuleFor(x => x.StartDate)
            .NotEmpty().WithMessage("StartDate is required");

        RuleFor(x => x.EndDate)
            .NotEmpty().WithMessage("EndDate is required")
            .GreaterThan(x => x.StartDate)
            .WithMessage("EndDate must be later than StartDate");

        RuleFor(x => x.BranchId)
            .NotEmpty().WithMessage("BranchId is required");
    }
}
