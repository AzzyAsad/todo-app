using Microsoft.EntityFrameworkCore;
using System;
using TodoApp.API.EndpointConfig;
using TodoApp.API.Enums;
using TodoApp.API.Persistence;

namespace TodoApp.API.Endpoints.TodoItem
{
    public class Get
    {
        public record Response(int Id, string Description, DateTime CompleteBy, string Status);

        public sealed class Endpoint : IEndpoint
        {
            public void MapEndpoint(IEndpointRouteBuilder app)
            {
                app.MapGet("TodoItem/{id}", Handler).WithTags("Todo Items");
            }
        }

        public static async Task<IResult> Handler(int id, TodoDbContext context)
        {
            var todoItem = await context.TodoItems.FindAsync(id);
            if (todoItem is null)
                return Results.NotFound();

            var respose = new Response(todoItem.Id, todoItem.Description, todoItem.CompleteBy, todoItem.Status.GetDisplayName());
            return Results.Ok(respose);
        }
    }
}
