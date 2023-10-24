using SystemDesignInitial.Domain.Aggregations;

namespace SystemDesignInitial.Domain.Abstractions.Queries;

public interface IGetCustomerByIdQuery
{
    Task<CustomerAggregation> ExecuteAsync(string id, CancellationToken cancellationToken);
}