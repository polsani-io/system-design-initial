namespace SystemDesignInitial.Responses;

public class CustomerResponse
{
    public string Id { get; set; }
    public string Name { get; set; }
    public int RiskScore { get; set; }
    public CreditCardResponse CreditCard { get; set; }
}