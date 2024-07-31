using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.Dtos;
using ToDoAppDomain.Entity;

namespace ToDoApp.Application.Interfaces
{
    public interface IToDoRepository
    {
        List<ToDoItem> GetAll();
        ToDoItem GetById(int id);

        ToDoItem Create(ToDoItem dto);

        bool Update(int id,UpdateToDoItemDto dto);
        bool Delete(int id);

        bool IsComplete(int id);

        ToDoItem Search(string keyword);

    }
}
