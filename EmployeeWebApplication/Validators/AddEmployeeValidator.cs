using EmployeeWebApplication.Dto;
using FluentValidation;

namespace EmployeeWebApplication.Validators
{
    public class AddEmployeeValidator : AbstractValidator<AddEmployeeRequestDto>
    {
        public AddEmployeeValidator()
        {
            RuleFor(e => e.Name)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Name can't be empty")
                    .WithErrorCode("Empty_Name")
                .MinimumLength(2)
                    .WithMessage("Name length must be at least 2.")
                    .WithErrorCode("Min_Name_Length")
                .MaximumLength(150)
                    .WithMessage("Name length must not exceed 150")
                    .WithErrorCode("Max_Name_Length");
        }
    }
}