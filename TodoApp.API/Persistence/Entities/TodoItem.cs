using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TodoApp.API.Enums;

namespace TodoApp.API.Persistence.Entities
{
    public class TodoItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }
        public string Description { get; set; }
        public TodoItemStatus Status { get; set; }
        public DateTime CompleteBy { get; set; }
    }
}
