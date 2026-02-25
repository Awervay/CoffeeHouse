using FluentValidation;
using Contract.Orders.Models.OrderItem;

namespace Validation.OrderItem;

public class UpdateOrderItemRequestValidator : AbstractValidator<UpdateOrderItemRequest>
{
    public UpdateOrderItemRequestValidator()
    {
        RuleFor(x => x.Quantity)
            .GreaterThan(0)
            .WithMessage("Quantity must be greater than 0");

        RuleFor(x => x.PriceAtPurchase)
            .GreaterThan(0)
            .WithMessage("PriceAtPurchase must be greater than 0");
    }
}
