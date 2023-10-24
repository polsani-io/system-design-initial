using SystemDesignInitial.Domain.Aggregations;

namespace SystemDesignInitial.Domain.Abstractions.Queries;

public interface IGetCustomersQuery
{
    Task<List<CustomerAggregation>> ExecuteAsync(CancellationToken cancellationToken);
}