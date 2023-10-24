using Microsoft.EntityFrameworkCore;
using SystemDesignInitial.Domain.Entities;
using SystemDesignInitial.Infra.Configurations;

namespace SystemDesignInitial.Infra.Database;

public class PostgresDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<CreditCard> CreditCards { get; set; }

    public PostgresDbContext(DbContextOptions<PostgresDbContext> context) : base(context)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        

        modelBuilder.Entity<CreditCard>()
            .Property(x=>x.Id)
            .IsRequired();
    }
}