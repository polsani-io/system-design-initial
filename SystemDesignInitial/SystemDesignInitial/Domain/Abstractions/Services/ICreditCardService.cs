using SystemDesignInitial.Domain.Entities;

namespace SystemDesignInitial.Domain.Abstractions.Services;

public interface ICreditCardService
{
    CreditCard GenerateCreditCard(Customer customer);
}