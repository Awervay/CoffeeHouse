using FluentValidation;
using Contract.Orders.Models.OrderItem;

namespace Validation.OrderItem;

public class CreateOrderItemRequestValidator : AbstractValidator<CreateOrderItemRequest>
{
    public CreateOrderItemRequestValidator()
    {
        RuleFor(x => x.Quantity)
            .GreaterThan(0)
            .WithMessage("Quantity must be greater than 0");

        RuleFor(x => x.PriceAtPurchase)
            .GreaterThan(0)
            .WithMessage("PriceAtPurchase must be greater than 0");

        RuleFor(x => x.OrderId)
            .NotEmpty()
            .WithMessage("OrderId is required");

        RuleFor(x => x.BranchProductId)
            .NotEmpty()
            .WithMessage("BranchProductId is required");
    }
}
