using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MinimalApi.Helpers;

namespace MinimalApi.Modules.Accounts.Endpoints;

public sealed class CreateAccountEndpoint : IEndpoint
{
    public static void Map(RouteGroupBuilder builder)
    {
        builder.MapPost("", HandleAsync)
            .AllowAnonymous()
            .RequireRequestValidation()
            .Produces(201)
            .ProducesProblem(400)
            .ProducesProblem(401)
            .WithName("CreateAccount")
            .WithDescription("Creates new account.")
            .WithSummary("Request for AS")
            .WithOpenApi();
    }

    private static IResult HandleAsync(
        [FromBody] CreateAccountRequest req,
        [FromServices] ILogger<CreateAccountEndpoint> logger,
        CancellationToken ct)
    {
        logger.LogInformation(req.ToString());
        return Results.StatusCode(201);
    }
}