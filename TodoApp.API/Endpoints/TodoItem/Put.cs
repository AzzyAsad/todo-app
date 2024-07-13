using FluentValidation;
using TodoApp.API.EndpointConfig;
using TodoApp.API.Enums;
using TodoApp.API.Persistence;

namespace TodoApp.API.Endpoints.TodoItem
{
    public class Put
    {
        public record Request(DateTime CompletedOn);
        public record Response(int Id, string Description, DateTime CompleteBy, string Status);

        public sealed class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(r => r.CompletedOn).NotEmpty();
            }
        }

        public sealed class Endpoint : IEndpoint
        {
            public void MapEndpoint(IEndpointRouteBuilder app)
            {
                app.MapPut("TodoItem/{id}", Handler).WithTags("Todo Items");
            }
        }

        public static async Task<IResult> Handler(int id, Request request, TodoDbContext context, IValidator<Request> validator)
        {
            var validationResult = await validator.ValidateAsync(request);
            if (!validationResult.IsValid)
                return Results.BadRequest(validationResult.Errors.First().ErrorMessage);

            var todoItem = await context.TodoItems.FindAsync(id);
            if (todoItem is null)
                return Results.NotFound();

            todoItem.CompleteBy = request.CompletedOn;
            todoItem.Status = TodoItemStatus.Completed;

            await context.SaveChangesAsync();

            return Results.Ok(new Response(todoItem.Id, todoItem.Description, todoItem.CompleteBy, todoItem.Status.GetDisplayName()));
        }
    }
}
