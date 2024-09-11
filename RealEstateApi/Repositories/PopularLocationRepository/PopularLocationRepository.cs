using Dapper;
using RealEstateApi.Dto.PopularLocationDtos;
using RealEstateApi.Models.DapperContext;

namespace RealEstateApi.Repositories.PopularLocationRepository;

public class PopularLocationRepository : IPopularLocationRepository
{
    private readonly Context _context;
    public PopularLocationRepository(Context context)
    {
        _context = context;
    }
    public async Task<List<ResultPopularLocationDto>> GetAllPopularLocationAsync()
    {
      string query = "SELECT * FROM popular_location";
      using var connection = _context.CreateConnection();
      var result = await connection.QueryAsync<ResultPopularLocationDto>(query);
      return result.ToList();
    }

    public async void CreatePopularLocationAsync(CreatePopularLocationDto createPopularLocationDto)
    {
       string query = "INSERT INTO popular_location (city_name, image_url) VALUES (@CityName, @ImageUrl)";
       var parameters = new DynamicParameters();
       parameters.Add("@CityName", createPopularLocationDto.CityName); 
       parameters.Add("@ImageUrl", createPopularLocationDto.ImageUrl);
       using var connection = _context.CreateConnection();
       await connection.ExecuteAsync(query, parameters);
    }

    public async void DeletePopularLocationAsync(int id)
    {
        string query = "DELETE FROM popular_location WHERE LocationId = @LocationId";
        var parameters = new DynamicParameters();
        parameters.Add("@LocationId", id);
        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync(query, parameters);
    }

    public async Task UpdatePopularLocationAsync(UpdatePopularLocationDto updatePopularLocationDto)
    {
         string query = "UPDATE popular_location SET city_name = @CityName, image_url = @ImageUrl WHERE LocationId = @LocationId";
         var parameters = new DynamicParameters();
         parameters.Add("@CityName", updatePopularLocationDto.CityName);
         parameters.Add("@ImageUrl", updatePopularLocationDto.ImageUrl); 
         parameters.Add("@LocationId", updatePopularLocationDto.LocationId);
         using var connection = _context.CreateConnection();
         await connection.ExecuteAsync(query, parameters);
    }

    public async Task<GetByIdPopularLocationDto> GetByIdPopularLocationAsync(int id)
    {
        string query = "SELECT * FROM popular_location WHERE LocationId = @LocationId";
        var parameters = new DynamicParameters();
        parameters.Add("@LocationId", id);
        using var connection = _context.CreateConnection();
        var result = await connection.QueryFirstOrDefaultAsync<GetByIdPopularLocationDto>(query, parameters);
        return result;
    }
}