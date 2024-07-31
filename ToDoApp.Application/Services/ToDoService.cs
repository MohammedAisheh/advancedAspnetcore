using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.Dtos;
using ToDoApp.Application.Interfaces;
using ToDoAppDomain.Entity;

namespace ToDoApp.Application.Services
{
    public class ToDoService
    {
        private readonly IToDoRepository _repository;
    
        public ToDoService(IToDoRepository repository)
        {
            _repository = repository;

        }

        public List<ToDoItemDto> GetAll()
        { 
        var result  = _repository.GetAll();
            //var mappingReuslt = result.Select(todoItem => new ToDoItemDto() { 
            //Description = todoItem.Description,
            //Title= todoItem.Title,
            //DueDate = todoItem.DueDate,
            //Id = todoItem.Id,
            //PriorityLevel = todoItem.PriorityLevel,
            //Tags = todoItem.Tags,
            //UserId = todoItem.UserId
            //});
            var mappedResult = result.Adapt<List<ToDoItemDto>>();
            return mappedResult;
        }

        public ToDoItemDto  Create(CreateToDoItemDto dto) 
        {
            var todoItem = dto.Adapt<ToDoItem>();
            _repository.Create(todoItem);
            return todoItem.Adapt<ToDoItemDto>();

        }

        public ToDoItemDto GetById(int id)
        {
            var todoItem = _repository.GetById(id);
            return todoItem.Adapt<ToDoItemDto>();

        }
        public bool Update(int id,UpdateToDoItemDto dto)
        {
           return _repository.Update(id, dto);


        }

        public bool Delete(int id)
        {
            return _repository.Delete(id);


        }

        public bool IsComplete(int id)
        {
            return _repository.IsComplete(id);


        }

        public ToDoItem Search(string keyword)
        {
            return _repository.Search(keyword);


        }

    }

}
