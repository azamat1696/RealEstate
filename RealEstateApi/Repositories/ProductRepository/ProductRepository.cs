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
        string query = "SELECT *,CategoryName FROM products p LEFT JOIN categroies c ON p.ProductCategory = c.CategoryId";
        using (var connection = _context.CreateConnection())
        {
            var values = await connection.QueryAsync<ResultProductWithCategoryDto>(query);
            return values.ToList();
        }
    }
}