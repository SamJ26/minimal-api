namespace MinimalApi;

public interface IEndpoint
{
    static abstract void Map(RouteGroupBuilder builder);
}