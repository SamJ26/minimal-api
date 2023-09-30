using FluentValidation;
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
    
    private static IResult HandleAsync(
        [FromBody] CreateAccountRequest req,
        [FromServices] IValidator<CreateAccountRequest> validator,
        [FromServices] ILogger<CreateAccountEndpoint> logger,
        CancellationToken ct)
    {
        var validationResult = validator.Validate(req);
        if (!validationResult.IsValid)
        {
            return TypedResults.ValidationProblem(validationResult.ToDictionary());
        }
        
        logger.LogInformation(req.ToString());
        
        return Results.StatusCode(201);
    }
}