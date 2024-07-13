using FluentValidation;
using System;
using TodoApp.API.EndpointConfig;
using TodoApp.API.Enums;
using TodoApp.API.Persistence;

namespace TodoApp.API.Endpoints.TodoItem
{
    public class Post
    {
        public record Request(string Description, DateTime CompleteBy);
        public record Response(int Id, string Description, DateTime CompleteBy, string Status);

        public sealed class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(r => r.Description).NotEmpty().MinimumLength(11);
                RuleFor(r => r.CompleteBy).NotEmpty();
            }
        }

        public sealed class Endpoint : IEndpoint
        {
            public void MapEndpoint(IEndpointRouteBuilder app)
            {
                app.MapPost("TodoItem", Handler).WithTags("Todo Items");
            }
        }

        public static async Task<IResult> Handler(Request request, TodoDbContext context, IValidator<Request> validator)
        {
            var validationResult = await validator.ValidateAsync(request);
            if (!validationResult.IsValid)
                return Results.BadRequest(validationResult.Errors.First().ErrorMessage);

            var todoItem = new Persistence.Entities.TodoItem { Description = request.Description, CompleteBy = request.CompleteBy, Status = TodoItemStatus.InProgress };
            context.TodoItems.Add(todoItem);
            await context.SaveChangesAsync();

            return Results.Ok(new Response(todoItem.Id, todoItem.Description, todoItem.CompleteBy, todoItem.Status.GetDisplayName()));
        }
    }
}
