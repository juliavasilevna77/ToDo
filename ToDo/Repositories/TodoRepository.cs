using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ToDo.Repositories.Interfaces;
using ToDoListMVC.Data;
using ToDoListMVC.Models;

namespace ToDo.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly AppDbContext appDbContext;

        public TodoRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public IEnumerable<Item> AllItems => appDbContext.Items;

        public Item Add(Item newItem)
        {
            appDbContext.Items.Add(newItem);
            return newItem;
        }

        public Item GetItemById(int id)
        {
            return appDbContext.Items.Find(id);
        }

        public Item Remove(int id)
        {
            var item = GetItemById(id);
            if (item != null)
            {
                appDbContext.Items.Remove(item);
            }
            return item;
        }

        public Item Update(Item updatedItem)
        {
            var entity = appDbContext.Items.Attach(updatedItem);
            entity.State = EntityState.Modified;
            return updatedItem;
        }

        public int Commit()
        {
            return appDbContext.SaveChanges();
        }
    }
}