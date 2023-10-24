using Microsoft.EntityFrameworkCore;
using SystemDesignInitial.Domain.Abstractions.Queries;
using SystemDesignInitial.Domain.Aggregations;
using SystemDesignInitial.Infra.Database;

namespace SystemDesignInitial.Domain.Queries.Customer;

public class GetCustomerById : IGetCustomerByIdQuery
{
    private readonly PostgresDbContext _dbContext;

    public GetCustomerById(PostgresDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<CustomerAggregation> ExecuteAsync(string id, CancellationToken cancellationToken)
    {
        //low performance
        var customer = await _dbContext.Customers.Include(x => x.CreditCard).Where(x => x.Id == Guid.Parse(id))
            .FirstAsync(cancellationToken);

        return new CustomerAggregation
        {
            CreditCard = customer.CreditCard,
            Customer = customer
        };
    }
}