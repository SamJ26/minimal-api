using FluentValidation;

namespace MinimalApi.Modules.Accounts.Endpoints;

public sealed class CreateAccountRequestValidator : AbstractValidator<CreateAccountRequest>
{
    public CreateAccountRequestValidator()
    {
        RuleFor(e => e.FirstName)
            .NotEmpty();

        RuleFor(e => e.LastName)
            .NotEmpty();
    }
}