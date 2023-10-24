using SystemDesignInitial.Domain.Entities;

namespace SystemDesignInitial.Domain.Abstractions.Specifications;

public interface IRiskSpecification
{
    int Score { get; }
    bool CanApply(Customer customer);
}