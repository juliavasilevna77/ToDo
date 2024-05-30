using ToDoListMVC.Models;

namespace ToDoListMVC.ViewModels
{
    public class TodoItemWIthMessageViewModel
    {
        public Item Item { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}