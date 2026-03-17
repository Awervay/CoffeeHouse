using FluentValidation;
using Contract.Branches.Models.Branch;

namespace Validation.Branch;

public class UpdateBranchRequestValidator : AbstractValidator<UpdateBranchRequest>
{
    public UpdateBranchRequestValidator()
    {
        RuleFor(x => x.City)
            .NotEmpty().WithMessage("City is required")
            .MaximumLength(100);

        RuleFor(x => x.Country)
            .NotEmpty().WithMessage("Country is required")
            .MaximumLength(100);

        RuleFor(x => x.Address)
            .NotEmpty().WithMessage("Address is required")
            .MaximumLength(200);

        RuleFor(x => x.CoffeeChainId)
            .NotEmpty().WithMessage("CoffeeChainId is required");
    }
}
