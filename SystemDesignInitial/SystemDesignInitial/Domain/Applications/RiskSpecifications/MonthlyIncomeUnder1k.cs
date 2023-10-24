using SystemDesignInitial.Domain.Abstractions.Specifications;
using SystemDesignInitial.Domain.Entities;

namespace SystemDesignInitial.Domain.Applications.RiskSpecifications;

public class MonthlyIncomeUnder1K : IRiskSpecification
{
    public int Score => 5;
    
    public bool CanApply(Customer customer)
    {
        return customer.MonthlyIncome <= 1000;
    }
}