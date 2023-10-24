using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using SystemDesignInitial.Domain.Abstractions.Queries;
using SystemDesignInitial.Domain.Abstractions.Repositories;
using SystemDesignInitial.Domain.Abstractions.Services;
using SystemDesignInitial.Domain.Aggregations;
using SystemDesignInitial.Domain.Entities;
using SystemDesignInitial.Mappers;
using SystemDesignInitial.Requests;
using SystemDesignInitial.Responses;

namespace SystemDesignInitial.Controllers;

[ApiController]
[Route("customers")]
public class CustomerController : ControllerBase
{
    private readonly ICreditCardService _creditCardService;
    private readonly ICustomerAggregationRepository _customerAggregationRepository;
    private readonly IValidator<Customer> _customerValidator;

    public CustomerController(ICreditCardService creditCardService, ICustomerAggregationRepository customerAggregationRepository, 
        IValidator<Customer> customerValidator)
    {
        _creditCardService = creditCardService;
        _customerAggregationRepository = customerAggregationRepository;
        _customerValidator = customerValidator;
    }

    [HttpPost]
    [Route("")]
    public async Task<IActionResult> CreateCustomer([FromBody]CreateCustomerRequest request, CancellationToken cancellationToken)
    {
        var customer = CustomerMapper.ToEntity(request);
        var validationResult = await _customerValidator.ValidateAsync(customer, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var creditCard = _creditCardService.GenerateCreditCard(customer);
        var customerAggregation = new CustomerAggregation
        {
            CreditCard = creditCard,
            Customer = customer
        };

        await _customerAggregationRepository.SaveAsync(customerAggregation, cancellationToken);

        var response = CustomerMapper.ToResponse(customerAggregation);
        
        return Ok(response);
    }

    [HttpGet]
    [Route("")]
    public async Task<List<CustomerResponse>> GetCustomers([FromServices] IGetCustomersQuery query, CancellationToken cancellationToken)
    {
        var customersAggregations = await query.ExecuteAsync(cancellationToken);
        var response = customersAggregations.Select(CustomerMapper.ToResponse).ToList();
        
        return response;
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<CustomerResponse> GetCustomer([FromRoute]string id, [FromServices] IDistributedCache distributedCache,
        [FromServices] IGetCustomerByIdQuery query, CancellationToken cancellationToken)
    {
        /* Cache session
        var jsonCachedObject = await distributedCache.GetStringAsync(id, cancellationToken);
        
        if (jsonCachedObject != null)
        {
            var cachedResponse = JsonSerializer.Deserialize<CustomerResponse>(jsonCachedObject);
            if (cachedResponse is not null)
                return cachedResponse;
            
            await distributedCache.RemoveAsync(id, cancellationToken);

            return await GetCustomer(id, distributedCache, cancellationToken);
        }*/

        var customerAggregation = await query.ExecuteAsync(id, cancellationToken);
        var customerResponse = CustomerMapper.ToResponse(customerAggregation);
        
        //await distributedCache.SetStringAsync(id, JsonSerializer.Serialize(customerResponse), cancellationToken);
        
        return customerResponse;
    }
}