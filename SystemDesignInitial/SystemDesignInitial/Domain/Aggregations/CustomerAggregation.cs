using SystemDesignInitial.Domain.Entities;

namespace SystemDesignInitial.Domain.Aggregations;

public class CustomerAggregation
{
    public Customer Customer { get; set; }
    public CreditCard CreditCard { get; set; }
}