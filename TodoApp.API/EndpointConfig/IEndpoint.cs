namespace TodoApp.API.EndpointConfig
{
    public interface IEndpoint
    {
        void MapEndpoint(IEndpointRouteBuilder app);
    }
}
