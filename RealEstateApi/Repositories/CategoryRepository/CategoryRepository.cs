using Dapper;
using RealEstateApi.Dto;
using RealEstateApi.Models.DapperContext;

namespace RealEstateApi.Repositories.CategoryRepository;

public class CategoryRepository: ICategoryRepository
{
    private readonly Context _context;
    public CategoryRepository(Context context)
    {
        _context = context;
    }
    public async void CreateCategoryAsync(CreateCategoryDto createCategoryDto)
    {
        string query = "INSERT INTO categroies (CategoryName, CategoryStatus) VALUES (@CategoryName, @CategoryStatus)";
        var parameters = new DynamicParameters();
        parameters.Add("@CategoryName", createCategoryDto.CategoryName);
        parameters.Add("@CategoryStatus", createCategoryDto.CategoryStatus);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters); 
        }
    }
    public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
    {
         string query = "SELECT * FROM categroies";
         using (var connection = _context.CreateConnection())
         {
             var values = await connection.QueryAsync<ResultCategoryDto>(query);
             return values.ToList();
         }
    }
    public async void DeleteCategoryAsync(int categoryId)
    {
        string query = "DELETE FROM categroies WHERE CategoryId = @CategoryId";
        var parameters = new DynamicParameters();
        parameters.Add("@CategoryId", categoryId);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }
    public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
    {
        string query = "UPDATE categroies SET CategoryName = @CategoryName, CategoryStatus = @CategoryStatus WHERE CategoryId = @CategoryId";
        var parameters = new DynamicParameters();
        parameters.Add("@CategoryName", updateCategoryDto.CategoryName);
        parameters.Add("@CategoryStatus", updateCategoryDto.CategoryStatus);
        parameters.Add("@CategoryId", updateCategoryDto.CategoryId);
        using (var connection = _context.CreateConnection())
        {
             await connection.ExecuteAsync(query, parameters);
        }
    }
    public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(int categoryId)
    {
        string query = "SELECT * FROM categroies WHERE CategoryId = @CategoryId";
        var parameters = new DynamicParameters();
        parameters.Add("@CategoryId", categoryId);
        using (var connection = _context.CreateConnection())
        {
            return await connection.QueryFirstOrDefaultAsync<GetByIdCategoryDto>(query, parameters);;
        }
    }
}