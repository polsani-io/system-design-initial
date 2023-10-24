using FluentValidation;
using SystemDesignInitial.Domain.Entities;

namespace SystemDesignInitial.Domain.Validators;

public class CustomerValidator : AbstractValidator<Customer>
{
    public CustomerValidator()
    {
        RuleFor(customer => customer.Name).NotNull().NotEmpty();
        RuleFor(customer => customer.BirthDate).GreaterThanOrEqualTo(DateOnly.MinValue);
        
        RuleFor(customer => customer.MonthlyIncome).SetValidator(new MonthlyIncomeValidator());
        RuleFor(customer => customer.Email).SetValidator(new EmailValidator());
        RuleFor(customer => customer.Phone).SetValidator(new PhoneValidator());
    }
}