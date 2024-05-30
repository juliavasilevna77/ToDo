using System.Collections.Generic;
using ToDoListMVC.Models;

namespace ToDo.Repositories.Interfaces
{
    public interface ITodoRepository
    {
        IEnumerable<Item> AllItems { get; }
        Item GetItemById(int id);
        Item Add(Item newItem);
        Item Update(Item updatedItem);
        Item Remove(int id);
        int Commit();
    }
}