using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.Dtos;
using ToDoApp.Application.Interfaces;
using ToDoApp.Infrastructure.Data;
using ToDoAppDomain.Entity;

namespace ToDoApp.Infrastructure.Repositories
{
    public class ToDoItemRepository : IToDoRepository
    {
        private readonly AppDbContext _context;
        public ToDoItemRepository(AppDbContext context) 
        {
        _context = context;
        }
        ToDoItem IToDoRepository.Create(ToDoItem item)
        {
            _context.Add(item);
            _context.SaveChanges();
            return item;
        }

        public List<ToDoItem> GetAll()
        {
            return _context.ToDoItems.ToList();
        }

        public ToDoItem GetById(int id)
        {
            //return  _context.ToDoItems.Find(id);
            return _context.ToDoItems.FirstOrDefault(i => i.Id == id);
        }

        public bool Update(int id, UpdateToDoItemDto item)
        {
            var toDoItem = _context.ToDoItems.Find(id);
            if (toDoItem != null) 
            {
                toDoItem.Description = item.Description;
                toDoItem.Title = item.Title;
                toDoItem.Tags = item.Tags;
                toDoItem.DueDate = item.DueDate;
                toDoItem.PriorityLevel = item.PriorityLevel;
                _context.SaveChanges();
                return true;
            }
            return false;
        }


         public bool Delete(int id)
        {
            var DeleteItem = _context.ToDoItems.Find(id);
            _context.Remove(DeleteItem);
            _context.SaveChanges();
            return true;
        }

        public bool IsComplete(int id)
        {
            var toDoItem = _context.ToDoItems.Find(id);
            if (toDoItem != null)
            {
                toDoItem.IsComplete = true;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public ToDoItem Search(string keyword)
        {
            //return  _context.ToDoItems.Find(id);
            return _context.ToDoItems.FirstOrDefault(i => i.Title.Contains( keyword));

            //var todoItems = _context.ToDoItems.Where(i => i.Title.Contains(keyword));
            //return todoItems.ToList
        }


    }
}
