namespace MinimalApi.Modules.Accounts.Endpoints;

public sealed record CreateAccountRequest
{
    public string Name { get; init; } = null!;
}