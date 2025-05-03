using Dapper;
using RealEstateApi.Dto;
using RealEstateApi.Dto.ProductDtos;
using RealEstateApi.Models.DapperContext;

namespace RealEstateApi.Repositories.ProductRepository;

public class ProductRepository : IProductRepository
{
    private readonly Context _context;
    public ProductRepository(Context context)
    {
        _context = context;
    }
    public async Task<List<ResultProductDto>> GetAllProductsAsync()
    {
        string query = "SELECT * FROM products";
        using (var connection = _context.CreateConnection())
        {
            var values = await connection.QueryAsync<ResultProductDto>(query);
            return values.ToList();
        }
    }
    public async Task<List<ResultProductWithCategoryDto>> GetAllProductsWithCategoryAsync()
    {
        string query = "SELECT *,CategoryName FROM products p LEFT JOIN categories c ON p.ProductCategory = c.CategoryId";
        using (var connection = _context.CreateConnection())
        {
            var values = await connection.QueryAsync<ResultProductWithCategoryDto>(query);
            return values.ToList();
        }
    }
    public async void ProductDealOfTheDayStatusChangeToActive(int id)
    {
        string query = "UPDATE products SET DealOfTheDay = 1 WHERE ProductId = @id";
        var parameters = new DynamicParameters();
        parameters.Add("id", id);
        using (var connection = _context.CreateConnection())
        {
           await connection.ExecuteAsync(query, parameters);
        }
    }
    public async void ProductDealOfTheDayStatusChangeToPassive(int id)
    {
        string query = "UPDATE products SET DealOfTheDay = 0 WHERE ProductId = @id";
        var parameters = new DynamicParameters();
        parameters.Add("id", id);
        using (var connection = _context.CreateConnection())
        {
           await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task<List<ResultLastFiveProductWithCategoryDto>> GetLastFiveProductsAsync()
    {
        string query = "SELECT *, CategoryName FROM products p \nLEFT JOIN categories c ON p.ProductCategory = c.CategoryId \nWHERE p.Type='Kiralık' ORDER BY p.ProductId DESC LIMIT 5";
        using (var connection = _context.CreateConnection())
        {
            var values = await connection.QueryAsync<ResultLastFiveProductWithCategoryDto>(query);
            return values.ToList();
        }
    }
}