namespace SystemDesignInitial.Domain.CommonTypes;

public readonly struct MonthlyIncome
{
    private decimal Value { get; }

    public MonthlyIncome(decimal value)
    {
        Value = value;
    }
    
    public static implicit operator decimal(MonthlyIncome d) => d.Value;
    public static explicit operator MonthlyIncome(decimal b) => new (b);
}