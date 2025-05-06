using Microsoft.AspNetCore.Mvc;
using RealEstateApi.Dto.TodoListDtos;
using RealEstateApi.Repositories.TodoListRepositories;

namespace RealEstateApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodoListController : Controller
{
     private ITodoListRepository _todoListRepository;
     public TodoListController(ITodoListRepository todoListRepository)
     {
          _todoListRepository = todoListRepository;
     }
     [HttpGet]
     public async Task<IActionResult> GetAllTodoList()
     {
          var todoLists = await _todoListRepository.GetAllTodoListAsync();
          return Ok(todoLists);
     }
     [HttpPost]
     public async Task<IActionResult> CreateTodoList(CreateTodoListDto createTodoListDto)
     {
          _todoListRepository.CreateTodoListAsync(createTodoListDto);
          return Ok("Todo List Created");
     }
     [HttpDelete("{todoListId}")]
     public async Task<IActionResult> DeleteTodoList(int todoListId)
     {
          _todoListRepository.DeleteTodoListAsync(todoListId);
          return Ok("Todo List Deleted");
     }
     [HttpGet("{todoListId}")]
     public async Task<IActionResult> GetByIdTodoList(int todoListId)
     {
          var todoList = await _todoListRepository.GetByIdTodoListAsync(todoListId);
          return Ok(todoList);
     }
     [HttpPut]
     public async Task<IActionResult> UpdateTodoList(UpdateTodoListDto updateTodoListDto)
     {
          await _todoListRepository.UpdateTodoListAsync(updateTodoListDto);
          return Ok("Todo List Updated");
     }

     [HttpGet("GetLastFiveTodoList")]
     public async Task<IActionResult> GetLastFiveTodoList()
     {
         var result = await _todoListRepository.GetLastFiveTodoListAsync();
         return Ok(result);
     }
}