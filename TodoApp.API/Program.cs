using FluentValidation;
using Microsoft.EntityFrameworkCore;
using TodoApp.API.EndpointConfig;
using TodoApp.API.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(config =>
{
    config.CustomSchemaIds(x => $"{x.Name}_{Guid.NewGuid().ToString().Replace("-", "")}");
});

builder.Services.AddDbContext<TodoDbContext>(o => o.UseInMemoryDatabase("TodoDB"));
builder.Services.AddEndpoints();
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapEndpoints();
app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.Run();
