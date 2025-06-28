using Dapper;
using RealEstateApi.Dto.PropertyAmenityDtos;
using RealEstateApi.Models.DapperContext;

namespace RealEstateApi.Repositories.PropertyAmenityRepositories;

public class PropertyAmenityRepository : IPropertyAmenityRepository
{
    private readonly Context _context;

    public PropertyAmenityRepository(Context context)
    {
        _context = context;
    }

    public async Task<List<ResultPropertyAmenityByStatusTrueDto>> GetAllPropertyAmenityByStatusTrueAsync(int propertyId)
    {
        var query =
            "select a.id,a.Title  from property_amenities\nINNER JOIN amenities a ON property_amenities.AmenityId = a.id\nWHERE PropertyId = @propertyId and Status = 1";
        var parameters = new DynamicParameters();
        parameters.Add("propertyId", propertyId);
        using (var connection = _context.CreateConnection())
        {
            var result = await connection.QueryAsync<ResultPropertyAmenityByStatusTrueDto>(query, parameters);
            return result.ToList();
        }
    }
    
}