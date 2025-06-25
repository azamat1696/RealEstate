using Dapper;
using RealEstateApi.Dto.AppUserDtos;
using RealEstateApi.Models.DapperContext;

namespace RealEstateApi.Repositories.AppUserRepositories;

public class AppUserRepository : IAppUserRepository
{
    private readonly Context _context;

    public AppUserRepository(Context context)
    {
        _context = context;
    }

    public async Task<GetAppUserByProductIdDto> GetAppUsersByProductIdAsync(int productId)
    {
         string query = @"
            SELECT 
                au.id, 
                au.username, 
                au.email, 
                au.name, 
                au.image_url,
                au.phone
            FROM 
                app_user au
            JOIN 
                Products p ON p.AppUserId = au.id
            WHERE 
                p.ProductId = @ProductId";
         var parameters = new DynamicParameters();
            parameters.Add("ProductId", productId);
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryFirstOrDefaultAsync<GetAppUserByProductIdDto>(query, parameters);
                return result;
            }
    }
}