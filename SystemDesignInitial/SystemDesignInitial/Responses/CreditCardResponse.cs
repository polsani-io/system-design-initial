namespace SystemDesignInitial.Responses;

public class CreditCardResponse
{
    public string Number { get; set; }
    public string Name { get; set; }
    public int ExpirationMonth { get; set; }
    public int ExpirationYear { get; set; }
    public decimal Limit { get; set; }
}