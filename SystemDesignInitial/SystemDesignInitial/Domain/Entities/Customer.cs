using SystemDesignInitial.Domain.CommonTypes;

namespace SystemDesignInitial.Domain.Entities;

public class Customer
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateOnly BirthDate { get; set; }
    public MonthlyIncome MonthlyIncome { get; set; }
    public Occupation Occupation { get; set; }
    public Phone Phone { get; set; }
    public Email Email { get; set; }

    public virtual CreditCard CreditCard { get; set; }
}