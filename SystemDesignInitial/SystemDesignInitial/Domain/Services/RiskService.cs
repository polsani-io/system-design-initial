using SystemDesignInitial.Domain.Abstractions.Services;
using SystemDesignInitial.Domain.Abstractions.Specifications;
using SystemDesignInitial.Domain.Entities;

namespace SystemDesignInitial.Domain.Services;

public class RiskService : IRiskService
{
    private readonly IEnumerable<IRiskSpecification> _riskSpecifications;

    public RiskService(IEnumerable<IRiskSpecification> riskSpecifications)
    {
        _riskSpecifications = riskSpecifications;
    }

    public int CalculateRiskScore(Customer customer)
    {
        int riskScore = 0;

        foreach (var riskSpecification in _riskSpecifications)
        {
            if (riskSpecification.CanApply(customer))
                riskScore += riskSpecification.Score;
        }

        return riskScore;
    }
}