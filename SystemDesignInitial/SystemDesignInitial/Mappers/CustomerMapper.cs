using SystemDesignInitial.Domain.Aggregations;
using SystemDesignInitial.Domain.CommonTypes;
using SystemDesignInitial.Domain.Entities;
using SystemDesignInitial.Requests;
using SystemDesignInitial.Responses;

namespace SystemDesignInitial.Mappers;

public static class CustomerMapper
{
    public static Customer ToEntity(CreateCustomerRequest input)
    {
        if (!Enum.TryParse(input.Occupation, out Occupation occupation))
            occupation = Occupation.Undefined;
        
        return new Customer
        {
            MonthlyIncome = new MonthlyIncome(input.MonthlyIncome), 
            BirthDate = input.BirthDate, 
            Name = input.Name,
            Occupation =  occupation,
            Phone = new Phone(input.Phone),
            Email = new Email(input.Email),
            Id = Guid.NewGuid()
        };
    }

    public static CustomerResponse ToResponse(CustomerAggregation input)
    {
        return new CustomerResponse
        {
            CreditCard = CreditCardMapper.ToResponse(input.CreditCard),
            Id = input.Customer.Id.ToString()
        };
    }
}