namespace SystemDesignInitial.Domain.CommonTypes;

public class Email
{
    private string Value { get; set; }

    public Email(string value)
    {
        Value = value;
    }

    public static implicit operator string(Email e) => e.Value;
    public static explicit operator Email(string e) => new (e);
}