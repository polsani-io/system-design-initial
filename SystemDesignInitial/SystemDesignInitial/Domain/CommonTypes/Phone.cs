namespace SystemDesignInitial.Domain.CommonTypes;

public class Phone
{
    private string Value { get; set; }

    public Phone(string value)
    {
        Value = value;
    }

    public static implicit operator string(Phone e) => e.Value;
    public static explicit operator Phone(string e) => new (e);
}