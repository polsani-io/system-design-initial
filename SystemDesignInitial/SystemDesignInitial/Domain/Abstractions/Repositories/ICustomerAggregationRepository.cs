using SystemDesignInitial.Domain.Aggregations;

namespace SystemDesignInitial.Domain.Abstractions.Repositories;

public interface ICustomerAggregationRepository
{
    Task SaveAsync(CustomerAggregation customerAggregation, CancellationToken cancellationToken);
}