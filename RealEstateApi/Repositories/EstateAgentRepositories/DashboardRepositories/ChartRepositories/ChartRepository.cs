using Dapper;
using RealEstateApi.Dto.ChartDtos;
using RealEstateApi.Models.DapperContext;

namespace RealEstateApi.Repositories.EstateAgentRepositories.DashboardRepositories.ChartRepositories;

public class ChartRepository : IChartRepository
{
    private readonly Context _context;  

    public ChartRepository(Context context)
    {
        _context = context;
    }

    public async Task<List<ResultChartDto>> GetFiveCityChartData()
    {
         string query = "SELECT City,COUNT(*) as 'CityCount' FROM products GROUP BY City ORDER BY CityCount DESC LIMIT 5;";

         using (var connection = _context.CreateConnection())
         {
             var result = await connection.QueryAsync<ResultChartDto>(query);
             return result.ToList();
         }
         
    }
}