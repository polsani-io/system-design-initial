using SystemDesignInitial.Domain.Abstractions;
using SystemDesignInitial.Domain.Abstractions.Specifications;
using SystemDesignInitial.Domain.CommonTypes;

namespace SystemDesignInitial.Domain.Applications.CreditLimitSpecification;

public class ScoreBetween20And40 : ICreditLimitSpecification
{
    private const decimal LimitPercentage = 30;
    
    public bool CanApply(int riskScore)
    {
        return riskScore is > 20 and <= 40;
    }

    public decimal GetCreditLimit(MonthlyIncome monthlyIncome)
    {
        return monthlyIncome * LimitPercentage / 100;
    }
}