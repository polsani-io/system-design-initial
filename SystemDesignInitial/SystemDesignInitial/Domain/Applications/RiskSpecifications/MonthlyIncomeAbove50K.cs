using SystemDesignInitial.Domain.Abstractions.Specifications;
using SystemDesignInitial.Domain.Entities;

namespace SystemDesignInitial.Domain.Applications.RiskSpecifications;

public class MonthlyIncomeAbove50K : IRiskSpecification
{
    public int Score => 5;
    
    public bool CanApply(Customer customer)
    {
        return customer.MonthlyIncome > 50000;
    }
}