using FluentValidation;
using SystemDesignInitial.Domain.CommonTypes;

namespace SystemDesignInitial.Domain.Validators;

public class MonthlyIncomeValidator : AbstractValidator<MonthlyIncome>
{
    public MonthlyIncomeValidator()
    {
        
    }
}