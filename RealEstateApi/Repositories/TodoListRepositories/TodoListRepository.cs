using Dapper;
using RealEstateApi.Dto.TodoListDtos;
using RealEstateApi.Models.DapperContext;

namespace RealEstateApi.Repositories.TodoListRepositories;

public class TodoListRepository : ITodoListRepository
{
    private readonly Context _context;

    public TodoListRepository(Context context)
    {
        _context = context;
    }
    
    public async Task<List<ResultTodoListDto>> GetAllTodoListAsync()
    {
        string query = "SELECT * FROM todo_list";
        using (var connection = _context.CreateConnection())
        {
            var values = await connection.QueryAsync<ResultTodoListDto>(query);
            return values.ToList();
        }
        
    }

    public async void CreateTodoListAsync(CreateTodoListDto createTodoListDto)
    {
        string query = "INSERT INTO todo_list (task, completed) VALUES (@task, @completed)";
        var parameters = new DynamicParameters();
        parameters.Add("@task", createTodoListDto.task);
        parameters.Add("@completed", createTodoListDto.completed);
        using (var connection = _context.CreateConnection())
        {
           await connection.ExecuteAsync(query, parameters);
        }
    }

    public async void DeleteTodoListAsync(int todoListId)
    {
         string query = "DELETE FROM todo_list WHERE id = @id";
         var parameters = new DynamicParameters();
         parameters.Add("@id",  todoListId);
         using (var connection = _context.CreateConnection())
         {
                await connection.ExecuteAsync(query, parameters);
         }
    }

    public async Task UpdateTodoListAsync(UpdateTodoListDto updateTodoListDto)
    {
        string query = "UPDATE todo_list SET task = @task, completed = @completed WHERE id = @id";
        var parameters = new DynamicParameters();
        parameters.Add("@task", updateTodoListDto.task);
        parameters.Add("@completed", updateTodoListDto.completed);
        parameters.Add("@id", updateTodoListDto.id);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task<GetByIdTodoListDto> GetByIdTodoListAsync(int todoListId)
    {
        string query = "SELECT * FROM todo_list WHERE id = @id";
        var parameters = new DynamicParameters();
        parameters.Add("@id", todoListId);
        using (var connection = _context.CreateConnection())
        {
            return await connection.QueryFirstOrDefaultAsync<GetByIdTodoListDto>(query, parameters);
        }
    }
    public async Task<List<ResultTodoListDto>> GetLastFiveTodoListAsync()
    {
        string query = "SELECT * FROM todo_list ORDER BY id DESC LIMIT 5";
        using (var connection = _context.CreateConnection())
        {
            var result = await connection.QueryAsync<ResultTodoListDto>(query);
            return result.ToList();
        }
    }
}