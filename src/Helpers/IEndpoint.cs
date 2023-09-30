namespace MinimalApi.Helpers;

public interface IEndpoint
{
    static abstract void Map(RouteGroupBuilder builder);
}