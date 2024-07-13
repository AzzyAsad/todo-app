using Microsoft.EntityFrameworkCore;
using System;
using TodoApp.API.Persistence.Entities;

namespace TodoApp.API.Persistence
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; init; }
    }
}
