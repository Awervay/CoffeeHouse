using FluentValidation;
using Contract.Branches.Models.BranchProduct;

namespace Validation.BranchProduct;

public class CreateBranchProductRequestValidator : AbstractValidator<CreateBranchProductRequest>
{
    public CreateBranchProductRequestValidator()
    {
        RuleFor(x => x.BranchId)
            .NotEmpty().WithMessage("BranchId is required");

        RuleFor(x => x.ProductId)
            .NotEmpty().WithMessage("ProductId is required");

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Price must be greater than 0");
    }
}
