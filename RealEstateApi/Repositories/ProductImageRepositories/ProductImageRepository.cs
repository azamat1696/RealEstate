using Dapper;
using RealEstateApi.Dto.ProductImageDtos;
using RealEstateApi.Models.DapperContext;

namespace RealEstateApi.Repositories.ProductImageRepositories;

public class ProductImageRepository : IProductImageRepository
{
    private readonly Context _context;
    public ProductImageRepository(Context context)
    {
        _context = context;
    }
    
    public async Task<List<GetProductImageByProductIdDto>> GetProductImageByProductId(int productId)
    {
        string query = "SELECT * FROM product_image WHERE ProductId = @ProductId";
        var parameters = new DynamicParameters();
        parameters.Add("ProductId", productId);
        using (var connection = _context.CreateConnection())
        {
            var values = await connection.QueryAsync<GetProductImageByProductIdDto>(query, parameters);
            return values.ToList();
        }
    }
}