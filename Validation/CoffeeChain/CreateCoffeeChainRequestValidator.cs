using FluentValidation;
using Contract.Branches.Models.CoffeeChain;

namespace Validation.CoffeeChain;

public class CreateCoffeeChainRequestValidator : AbstractValidator<CreateCoffeeChainRequest>
{
    public CreateCoffeeChainRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(150);
    }
}
