using CarSales.CodingChallenge.Infrastructure.Dtos;
using FluentValidation;

namespace CarSales.CodingChallenge.Service.Validators
{
    public class CustomerValidator : AbstractValidator<CustomerDto>
    {
        public CustomerValidator()
        {
            RuleFor(cus => cus.Name).NotEmpty().WithMessage("Customer name is mandatory");
            RuleFor(cus => cus.VehicleType).IsInEnum().WithMessage("Vehicle type customer looking for is mandatory");
            RuleFor(cus => cus.SpeakingLanguage).IsInEnum().WithMessage("Customer speaking language is mandatory");
        }
    }
}
