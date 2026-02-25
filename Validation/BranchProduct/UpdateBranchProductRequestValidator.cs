using FluentValidation;
using Contract.Branches.Models.BranchProduct;

namespace Validation.BranchProduct;

public class UpdateBranchProductRequestValidator : AbstractValidator<UpdateBranchProductRequest>
{
    public UpdateBranchProductRequestValidator()
    {
        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Price must be greater than 0");
    }
}
