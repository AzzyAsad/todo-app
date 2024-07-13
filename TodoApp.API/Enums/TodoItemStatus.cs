using System.ComponentModel.DataAnnotations;

namespace TodoApp.API.Enums
{
    public enum TodoItemStatus
    {
        [Display(Name = "In Progress")]
        InProgress = 0,

        [Display(Name = "Completed")]
        Completed = 1
    }
}
