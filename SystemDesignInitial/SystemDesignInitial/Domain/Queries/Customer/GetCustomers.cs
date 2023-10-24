using Microsoft.EntityFrameworkCore;
using SystemDesignInitial.Domain.Abstractions.Queries;
using SystemDesignInitial.Domain.Aggregations;
using SystemDesignInitial.Infra.Database;

namespace SystemDesignInitial.Domain.Queries.Customer;

public class GetCustomers : IGetCustomersQuery
{
    private readonly PostgresDbContext _dbContext;

    public GetCustomers(PostgresDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<List<CustomerAggregation>> ExecuteAsync(CancellationToken cancellationToken)
    {
        //low performance
        return await _dbContext.Customers.Include(x => x.CreditCard).Select(x=> new CustomerAggregation
        {
            CreditCard = x.CreditCard,
            Customer = x
        }).ToListAsync(cancellationToken);
    }
}