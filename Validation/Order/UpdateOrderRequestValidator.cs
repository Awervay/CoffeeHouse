using FluentValidation;
using Contract.Orders.Models.Order;
using Contract.Orders.Models.Enum;

namespace Validation.Order;

public class UpdateOrderRequestValidator : AbstractValidator<UpdateOrderRequest>
{
    public UpdateOrderRequestValidator()
    {
        RuleFor(x => x.Status)
            .Must(value => Enum.IsDefined(typeof(OrderStatusModel), value))
            .WithMessage("Invalid order status");
    }
}
