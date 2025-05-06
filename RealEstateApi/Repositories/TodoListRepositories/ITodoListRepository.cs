using RealEstateApi.Dto.TodoListDtos;

namespace RealEstateApi.Repositories.TodoListRepositories;

public interface ITodoListRepository
{
    Task<List<ResultTodoListDto>> GetAllTodoListAsync();
    void CreateTodoListAsync(CreateTodoListDto createTodoListDto);
    void DeleteTodoListAsync(int todoListId);
    Task UpdateTodoListAsync(UpdateTodoListDto updateTodoListDto);
    Task<GetByIdTodoListDto> GetByIdTodoListAsync(int todoListId);
    Task<List<ResultTodoListDto>> GetLastFiveTodoListAsync();
}