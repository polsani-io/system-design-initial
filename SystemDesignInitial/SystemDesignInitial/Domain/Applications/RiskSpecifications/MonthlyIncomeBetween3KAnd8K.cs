using SystemDesignInitial.Domain.Abstractions.Specifications;
using SystemDesignInitial.Domain.Entities;

namespace SystemDesignInitial.Domain.Applications.RiskSpecifications;

public class MonthlyIncomeBetween3KAnd8K : IRiskSpecification
{
    public int Score => 10;
    
    public bool CanApply(Customer customer)
    {
        throw new NotImplementedException();
    }
}