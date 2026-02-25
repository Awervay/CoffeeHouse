using FluentValidation;
using Contract.Branches.Models.CoffeeChain;

namespace Validation.CoffeeChain;

public class UpdateCoffeeChainRequestValidator : AbstractValidator<UpdateCoffeeChainRequest>
{
    public UpdateCoffeeChainRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(150);
    }
}
