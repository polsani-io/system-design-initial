using SystemDesignInitial.Domain.Abstractions.Specifications;
using SystemDesignInitial.Domain.Entities;

namespace SystemDesignInitial.Domain.Applications.RiskSpecifications;

public class MonthlyIncomeBetween1KAnd3K : IRiskSpecification
{
    public int Score => 10;
    
    public bool CanApply(Customer customer)
    {
        return customer.MonthlyIncome > 1000 && customer.MonthlyIncome <= 3000;
    }
}