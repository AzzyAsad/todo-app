using Microsoft.EntityFrameworkCore;
using System;
using TodoApp.API.EndpointConfig;
using TodoApp.API.Enums;
using TodoApp.API.Persistence;

namespace TodoApp.API.Endpoints.TodoItem
{
    public class GetAll
    {
        public record Response(int Id, string Description, DateTime CompleteBy, string Status);

        public sealed class Endpoint : IEndpoint
        {
            public void MapEndpoint(IEndpointRouteBuilder app)
            {
                app.MapGet("TodoItems", Handler).WithTags("Todo Items");
            }
        }

        public static async Task<IResult> Handler(TodoDbContext context)
        {
            var todoItems = await context.TodoItems.OrderBy(x=>x.Id).ToListAsync();
            var respose = todoItems.Select(r => new Response(r.Id, r.Description, r.CompleteBy, r.Status.GetDisplayName()));
            return Results.Ok(respose);
        }
    }
}
