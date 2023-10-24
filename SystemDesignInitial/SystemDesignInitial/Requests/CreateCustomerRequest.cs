namespace SystemDesignInitial.Requests;

public class CreateCustomerRequest
{
    public string Name { get; set; }
    public DateOnly BirthDate { get; set; }
    public string Document { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Occupation { get; set; }
    public decimal MonthlyIncome { get; set; }
}