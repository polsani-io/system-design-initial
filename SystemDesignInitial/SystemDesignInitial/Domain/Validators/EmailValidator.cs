using FluentValidation;
using SystemDesignInitial.Domain.CommonTypes;

namespace SystemDesignInitial.Domain.Validators;

public class EmailValidator : AbstractValidator<Email>
{
    public EmailValidator()
    {
        
    }
}