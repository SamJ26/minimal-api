using Microsoft.AspNetCore.Mvc;

namespace MinimalApi.Modules.Accounts.Endpoints;

public sealed class CreateAccountEndpoint : IEndpoint
{
    public static void Map(RouteGroupBuilder builder)
    {
        builder.MapPost("", HandleAsync)
            .AllowAnonymous()
            .Produces(201)
            .ProducesProblem(400)
            .ProducesProblem(401)
            .WithName("CreateAccount")
            .WithDescription("Creates new account.")
            .WithSummary("Request for AS")
            .WithOpenApi();
    }
    
    private static Task<IResult> HandleAsync(
        [FromBody] CreateAccountRequest req,
        [FromServices] ILogger<CreateAccountEndpoint> logger)
    {
        logger.LogInformation(req.ToString());
        return Task.FromResult<IResult>(TypedResults.StatusCode(201));
    }
}