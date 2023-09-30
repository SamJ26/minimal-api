using MinimalApi.Modules.Invitations.Endpoints;
using MinimalApi.Modules.Invitations.Services;

namespace MinimalApi.Modules.Invitations;

public static class ModuleInstaller
{
    public static void UseInvitationsModule(this WebApplication app)
    {
        var builder = app
            .MapGroup("api/invitations")
            .WithTags("Invitations");

        GetInvitationStatusEndpoint.Map(builder);
    }

    public static void AddInvitationsModule(this IServiceCollection services)
    {
        services.AddSingleton<InvitationsManager>();
    }
}