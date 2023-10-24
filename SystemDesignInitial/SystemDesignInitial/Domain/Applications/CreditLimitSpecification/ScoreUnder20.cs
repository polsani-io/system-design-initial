using SystemDesignInitial.Domain.Abstractions;
using SystemDesignInitial.Domain.Abstractions.Specifications;
using SystemDesignInitial.Domain.CommonTypes;

namespace SystemDesignInitial.Domain.Applications.CreditLimitSpecification;

public class ScoreUnder20 : ICreditLimitSpecification
{
    private const decimal LimitPercentage = 20;
    
    public bool CanApply(int riskScore)
    {
        return riskScore <= 20;
    }

    public decimal GetCreditLimit(MonthlyIncome monthlyIncome)
    {
        return monthlyIncome * LimitPercentage / 100;
    }
}