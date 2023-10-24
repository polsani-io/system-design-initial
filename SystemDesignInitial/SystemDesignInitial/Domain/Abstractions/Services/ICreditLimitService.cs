using SystemDesignInitial.Domain.CommonTypes;

namespace SystemDesignInitial.Domain.Abstractions.Services;

public interface ICreditLimitService
{
    decimal CalculateCreditLimit(MonthlyIncome monthlyIncome, int riskScore);
}