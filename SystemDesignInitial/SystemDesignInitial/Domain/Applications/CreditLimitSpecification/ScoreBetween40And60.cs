using SystemDesignInitial.Domain.Abstractions;
using SystemDesignInitial.Domain.Abstractions.Specifications;
using SystemDesignInitial.Domain.CommonTypes;

namespace SystemDesignInitial.Domain.Applications.CreditLimitSpecification;

public class ScoreBetween40And60 : ICreditLimitSpecification
{
    private const decimal LimitPercentage = 40;
    
    public bool CanApply(int riskScore)
    {
        return riskScore is > 40 and <= 60;
    }

    public decimal GetCreditLimit(MonthlyIncome monthlyIncome)
    {
        return monthlyIncome * LimitPercentage / 100;
    }
}