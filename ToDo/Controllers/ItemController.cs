using Microsoft.AspNetCore.Mvc;
using ToDo.Repositories.Interfaces;
using ToDoListMVC.Models;
using ToDoListMVC.ViewModels;

namespace ToDoListMVC.Controllers
{
    public class ItemController : Controller
    {
        private readonly ITodoRepository todoRepository;

        [BindProperty]
        public Item Item { get; set; }

        [BindProperty]
        public TodoItemWIthMessageViewModel TodoViewModel { get; set; }

        public ItemController(ITodoRepository todoRepository)
        {
            this.todoRepository = todoRepository;
            TodoViewModel = new TodoItemWIthMessageViewModel();
        }

        [HttpGet]
        public IActionResult Create(int? itemId)
        {
            if (itemId.HasValue)
            {
                TodoViewModel.Item = todoRepository.GetItemById(itemId.Value);
                TodoViewModel.Message = "Item was successfully updated!";
            }
            else
            {
                TodoViewModel.Item = new Item();
                TodoViewModel.Message = "Item was successfully created!";
            }

            if (TodoViewModel.Item == null)
            {
                return RedirectToAction("NotFound");
            }
            return View(TodoViewModel);
        }

        [HttpPost]
        public IActionResult Create(TodoItemWIthMessageViewModel newItem)
        {
            if (!ModelState.IsValid)
            {
                return View(newItem);
            }

            if (newItem.Item.ID > 0)
            {
                todoRepository.Update(newItem.Item);
            }
            else
            {
                todoRepository.Add(newItem.Item);
            }

            todoRepository.Commit();
            TempData["Message"] = newItem.Message;
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int itemId)
        {
            Item = todoRepository.GetItemById(itemId);
            if (Item == null)
            {
                return RedirectToAction("NotFound");
            }
            return View(Item);
        }

        [HttpPost]
        public IActionResult Delete(int itemId)
        {
            var removedItem = todoRepository.Remove(itemId);

            if (removedItem == null)
            {
                return RedirectToAction("NotFound");
            }

            todoRepository.Commit();
            TempData["Message"] = "Item was successfully removed!";
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Done(int itemId)
        {
            var item = todoRepository.GetItemById(itemId);
            if (item != null)
            {
                if (item.Done)
                {
                    item.Done = false;
                }
                else
                {
                    item.Done = true;
                }
            }

            todoRepository.Commit();
            return RedirectToAction("Index", "Home");
        }
    }
}