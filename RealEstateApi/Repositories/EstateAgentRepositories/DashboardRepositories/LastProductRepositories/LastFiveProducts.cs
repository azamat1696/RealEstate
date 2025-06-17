using Dapper;
using RealEstateApi.Dto.ProductDtos;
using RealEstateApi.Models.DapperContext;

namespace RealEstateApi.Repositories.EstateAgentRepositories.DashboardRepositories.LastProductRepositories;

public class LastFiveProducts : ILastFiveProducts
{
    private readonly Context _context;
    public LastFiveProducts(Context context)
    {
        _context = context;
    }
    public async Task<List<ResultLastFiveProductWithCategoryDto>> GetLastFiveProductsAsync(int employeeId)
    {
        string query = "SELECT *, CategoryName FROM products p \nLEFT JOIN categories c ON p.ProductCategory = c.CategoryId \nWHERE  p.EmployeeId=@employeeId ORDER BY p.ProductId DESC LIMIT 5";
        var parameters = new DynamicParameters();
        parameters.Add("employeeId", employeeId);
        using (var connection = _context.CreateConnection())
        {
            var values = await connection.QueryAsync<ResultLastFiveProductWithCategoryDto>(query, parameters);
            return values.ToList();
        }
    }
}