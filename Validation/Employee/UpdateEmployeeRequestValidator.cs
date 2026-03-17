using FluentValidation;
using Contract.Staff.Models.Employee;

namespace Validation.Employee;

public class UpdateEmployeeRequestValidator : AbstractValidator<UpdateEmployeeRequest>
{
    public UpdateEmployeeRequestValidator()
    {
        RuleFor(x => x.FullName)
            .NotEmpty().WithMessage("FullName is required")
            .MaximumLength(150);

        RuleFor(x => x.PositionId)
            .NotEmpty().WithMessage("PositionId is required");

        RuleFor(x => x.BranchId)
            .NotEmpty().WithMessage("BranchId is required");
    }
}
