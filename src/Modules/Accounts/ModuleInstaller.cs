using MinimalApi.Modules.Accounts.Endpoints;

namespace MinimalApi.Modules.Accounts;

public static class ModuleInstaller
{
    public static void UseAccountsModule(this WebApplication app)
    {
        var builder = app
            .MapGroup("api/accounts")
            .WithTags("Accounts");

        CreateAccountEndpoint.Map(builder);
    }

    public static void AddAccountsModule(this IServiceCollection services)
    {
    }
}