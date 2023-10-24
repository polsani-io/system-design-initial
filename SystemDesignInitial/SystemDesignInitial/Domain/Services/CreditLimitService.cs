using SystemDesignInitial.Domain.Abstractions.Services;
using SystemDesignInitial.Domain.Abstractions.Specifications;
using SystemDesignInitial.Domain.CommonTypes;

namespace SystemDesignInitial.Domain.Services;

public class CreditLimitService : ICreditLimitService
{
    private readonly IEnumerable<ICreditLimitSpecification> _creditLimitSpecifications;

    public CreditLimitService(IEnumerable<ICreditLimitSpecification> creditLimitSpecifications)
    {
        _creditLimitSpecifications = creditLimitSpecifications;
    }

    public decimal CalculateCreditLimit(MonthlyIncome monthlyIncome, int riskScore)
    {
        decimal creditLimit = 0;
        
        foreach (var creditLimitSpecification in _creditLimitSpecifications)
        {
            if (creditLimitSpecification.CanApply(riskScore))
                creditLimit = creditLimitSpecification.GetCreditLimit(monthlyIncome);
        }

        return creditLimit;
    }
}