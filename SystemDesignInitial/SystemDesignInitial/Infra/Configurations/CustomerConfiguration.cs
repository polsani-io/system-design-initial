using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SystemDesignInitial.Domain.CommonTypes;
using SystemDesignInitial.Domain.Entities;

namespace SystemDesignInitial.Infra.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customer");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Email)
            .HasConversion(x => x.ToString(), y => new Email(y));
        
        builder.Property(x => x.MonthlyIncome)
            .HasConversion(x => (decimal)x, y => new MonthlyIncome(y));
        
        builder.Property(x => x.Phone)
            .HasConversion(x => x.ToString(), y => new Phone(y));
        
    }
}