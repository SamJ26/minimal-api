namespace MinimalApi.Helpers;

public static class RouteHandlerBuilderExtensions
{
    public static RouteHandlerBuilder RequireRequestValidation(this RouteHandlerBuilder builder)
    {
        return builder.AddEndpointFilter<ValidationEndpointFilter>();
    }
}