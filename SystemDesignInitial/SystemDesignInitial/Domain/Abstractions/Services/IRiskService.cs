using SystemDesignInitial.Domain.Entities;

namespace SystemDesignInitial.Domain.Abstractions.Services;

public interface IRiskService
{
    int CalculateRiskScore(Customer customer);
}