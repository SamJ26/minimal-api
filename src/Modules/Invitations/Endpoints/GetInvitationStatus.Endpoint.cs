using Microsoft.AspNetCore.Mvc;
using MinimalApi.Modules.Invitations.Services;

namespace MinimalApi.Modules.Invitations.Endpoints;

public sealed class GetInvitationStatusEndpoint : IEndpoint
{
    public static void Map(RouteGroupBuilder builder)
    {
        builder.MapPost("", HandleAsync)
            .AllowAnonymous()
            .Produces(200, typeof(GetInvitationStatusResponse))
            .ProducesProblem(400)
            .ProducesProblem(401)
            .WithName("GetInvitationStatus")
            .WithDescription("Returns status of the invitation specified in query string.")
            .WithSummary("Request for AS")
            .WithOpenApi();
    }
    
    private static IResult HandleAsync(
        [FromQuery] string token,
        [FromServices] InvitationsManager invitationsManager,
        [FromServices] ILogger<GetInvitationStatusEndpoint> logger,
        CancellationToken ct)
    {
        logger.LogInformation("Value of token from query string is: {Value}", token);
        var isValid = invitationsManager.Verify(token);
        return Results.Ok(new GetInvitationStatusResponse() { IsValid = isValid });
    }
}