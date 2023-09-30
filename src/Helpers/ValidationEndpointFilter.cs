using FluentValidation;

namespace MinimalApi.Helpers;

public sealed class ValidationEndpointFilter : IEndpointFilter
{
    private readonly IServiceProvider _serviceProvider;

    public ValidationEndpointFilter(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        foreach (var arg in context.Arguments)
        {
            if (arg is null || !arg.GetType().IsClass)
            {
                continue;
            }

            var argType = arg.GetType();
            var validatorType = typeof(IValidator<>).MakeGenericType(argType);
            var validationService = _serviceProvider.GetService(validatorType);

            if (validationService is not null && validationService is IValidator validator)
            {
                var validationResult = await validator.ValidateAsync(new ValidationContext<object>(arg));
                if (!validationResult.IsValid)
                {
                    return Results.ValidationProblem(validationResult.ToDictionary());
                }
            }
        }

        return await next(context);
    }
}