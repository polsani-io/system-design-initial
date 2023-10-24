using SystemDesignInitial.Domain.Abstractions;
using SystemDesignInitial.Domain.Abstractions.Specifications;
using SystemDesignInitial.Domain.CommonTypes;

namespace SystemDesignInitial.Domain.Applications.CreditLimitSpecification;

public class ScoreAbove60 : ICreditLimitSpecification
{
    private const decimal LimitPercentage = 50;
    
    public bool CanApply(int riskScore)
    {
        return riskScore > 60;
    }

    public decimal GetCreditLimit(MonthlyIncome monthlyIncome)
    {
        return monthlyIncome * LimitPercentage / 100;
    }
}