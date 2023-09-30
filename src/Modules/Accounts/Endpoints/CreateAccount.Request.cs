namespace MinimalApi.Modules.Accounts.Endpoints;

public sealed record CreateAccountRequest
{
    public string FirstName { get; init; } = null!;
    public string LastName { get; init; } = null!;
}