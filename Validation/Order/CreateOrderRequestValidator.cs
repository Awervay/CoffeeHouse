using FluentValidation;
using Contract.Orders.Models.Order;

namespace Validation.Order;

public class CreateOrderRequestValidator : AbstractValidator<CreateOrderRequest>
{
    public CreateOrderRequestValidator()
    {
        RuleFor(x => x.CustomerName)
            .MaximumLength(100)
            .WithMessage("CustomerName cannot exceed 100 characters");

        RuleFor(x => x.BranchId)
            .NotEmpty()
            .WithMessage("BranchId is required");
    }
}
