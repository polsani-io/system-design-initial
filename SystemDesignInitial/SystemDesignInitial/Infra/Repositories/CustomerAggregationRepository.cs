using SystemDesignInitial.Domain.Abstractions.Repositories;
using SystemDesignInitial.Domain.Aggregations;
using SystemDesignInitial.Infra.Database;

namespace SystemDesignInitial.Infra.Repositories;

public class CustomerAggregationRepository : ICustomerAggregationRepository
{
    private readonly PostgresDbContext _dbContext;

    public CustomerAggregationRepository(PostgresDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task SaveAsync(CustomerAggregation customerAggregation, CancellationToken cancellationToken)
    {
        _dbContext.Customers.Add(customerAggregation.Customer);
        _dbContext.CreditCards.Add(customerAggregation.CreditCard);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}