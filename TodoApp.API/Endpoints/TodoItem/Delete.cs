using FluentValidation;
using TodoApp.API.EndpointConfig;
using TodoApp.API.Persistence;

namespace TodoApp.API.Endpoints.TodoItem
{
    public class Delete
    {
        public sealed class Endpoint : IEndpoint
        {
            public void MapEndpoint(IEndpointRouteBuilder app)
            {
                app.MapDelete("TodoItem/{id}", Handler).WithTags("Todo Items");
            }
        }

        public static async Task<IResult> Handler(int id, TodoDbContext context)
        {
            var todoItem = await context.TodoItems.FindAsync(id);
            if (todoItem is null)
                return Results.NotFound();

            context.Remove(todoItem);
            await context.SaveChangesAsync();

            return Results.NoContent();
        }
    }
}
