using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Application.Dtos;
using ToDoApp.Application.Services;

namespace ToDoApp.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoItemController : ControllerBase
    {   
        private readonly ToDoService  _service;
        public ToDoItemController(ToDoService service)
        {
            _service = service;
        }


        [HttpGet] 
        public IActionResult Get()
        { 
        return Ok(_service.GetAll());
        }

        [HttpPost]
        public IActionResult Post(CreateToDoItemDto item)
        {
            _service.Create(item);
            return Ok();
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {   var item = _service.GetById(id);
            if (item is null)
            {

                return NotFound();
            }

            return Ok(_service.GetById(id));
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id,UpdateToDoItemDto dto)
        {
          var result = _service.Update(id, dto);
            if (result)
            {
                return Ok();
            }
            return BadRequest("Update Operattion failed");
            
        }
        
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var result = _service.Delete(id);
            if (result)
            {
                return Ok();
            }
            return BadRequest("Delete Operattion failed");
        }

        [ HttpPut ("Complete/{id:int}")]
        public IActionResult IsComplete(int id)
        {
            var result = _service.IsComplete(id);
            if (result)
            {
                return Ok();
            }
            return BadRequest("Update Operattion failed");

        }


        [HttpGet("{keyword}")]
        public IActionResult Search(string keyword)
        {
            var item = _service.Search(keyword);
            if (item is null)
            {

                return NotFound();
            }

            return Ok(_service.Search(keyword));
        }


        [HttpGet("test")]
        public IActionResult test(string keyword)
        {

            return Ok("test");
        }

    }
}
