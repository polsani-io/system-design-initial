using SystemDesignInitial.Domain.Entities;
using SystemDesignInitial.Responses;

namespace SystemDesignInitial.Mappers;

public static class CreditCardMapper
{
    public static CreditCardResponse ToResponse(CreditCard input)
    {
        return new CreditCardResponse
        {
            ExpirationMonth = input.ExpirationMonth,
            ExpirationYear = input.ExpirationYear,
            Limit = input.CreditLimit,
            Name = input.Name,
            Number = input.Number
        };
    }
}