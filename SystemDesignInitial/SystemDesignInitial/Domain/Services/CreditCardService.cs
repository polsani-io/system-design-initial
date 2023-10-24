using SystemDesignInitial.Domain.Abstractions.Services;
using SystemDesignInitial.Domain.Entities;

namespace SystemDesignInitial.Domain.Services;

public class CreditCardService : ICreditCardService
{
    public CreditCard GenerateCreditCard(Customer customer)
    {
        return new CreditCard();
    }
}