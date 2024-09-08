using Dapper;
using RealEstateApi.Dto.BottomGridDtos;
using RealEstateApi.Models.DapperContext;

namespace RealEstateApi.Repositories.BottomGridRepository;

public class BottomGridRepository : IBottomGridRepository
{
    private readonly Context _context;
    public BottomGridRepository(Context context)
    {
        _context = context;
    }
    public async Task<List<ResultBottomGridDto>> GetAllBottomGridAsync()
    {
         string query = "SELECT * FROM bottom_grid";
         using (var connetion = _context.CreateConnection())
         {
             var result = await connetion.QueryAsync<ResultBottomGridDto>(query);
             return result.ToList();
         }
        
    }

    public async void CreateBottomGridAsync(CreateBottomGridDto createBottomGridDto)
    {
        string query = "INSERT INTO bottom_grid (Icon, Title, Description) VALUES (@Icon, @Title, @Description)";
        var parameters = new DynamicParameters();
        parameters.Add("Icon", createBottomGridDto.Icon);
        parameters.Add("Title", createBottomGridDto.Title);
        parameters.Add("Description",createBottomGridDto.Description);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async void DeleteBottomGridAsync(int id)
    {
        string query = "DELETE FROM bottom_grid WHERE BottomGridId = @BottomGridId";
        var parameters = new DynamicParameters();
        parameters.Add("BottomGridId", id);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task UpdateBottomGridAsync(UpdateBottomGridDto updateBottomGridDto)
    {
        string query = "UPDATE bottom_grid SET Icon = @Icon, Title = @Title, Description = @Description WHERE BottomGridId = @BottomGridId";
        var parameters = new DynamicParameters();
        parameters.Add("Title",updateBottomGridDto.Title);
        parameters.Add("Icon",updateBottomGridDto.Icon);
        parameters.Add("Description",updateBottomGridDto.Description);
        parameters.Add("BottomGridId",updateBottomGridDto.BottomGridId);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task<GetByIdBottomGridDto> GetByIdBottomGridAsync(int id)
    {
        string query = "SELECT * FROM bottom_grid WHERE BottomGridId = @BottomGridId";
        var parameters = new DynamicParameters();
        parameters.Add("BottomGridId", id);
        using (var connection = _context.CreateConnection())
        {
            var result = await connection.QueryFirstOrDefaultAsync<GetByIdBottomGridDto>(query, parameters);
            return result;
        }
    }
}