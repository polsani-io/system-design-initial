using SystemDesignInitial.Domain.CommonTypes;

namespace SystemDesignInitial.Domain.Abstractions.Specifications;

public interface ICreditLimitSpecification
{
    bool CanApply(int riskScore);
    decimal GetCreditLimit(MonthlyIncome monthlyIncome);
}