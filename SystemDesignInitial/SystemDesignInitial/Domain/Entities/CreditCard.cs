namespace SystemDesignInitial.Domain.Entities;

public class CreditCard
{
    public Guid Id { get; set; }
    public decimal CreditLimit { get; set; }
    public string Number { get; set; }
    public string Name { get; set; }
    public int ExpirationMonth { get; set; }
    public int ExpirationYear { get; set; }
    public Guid CustomerId { get; set; }
    public virtual Customer Customer { get; set; }
}