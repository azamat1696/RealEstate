using RealEstateApi.Dto.PropertyAmenityDtos;

namespace RealEstateApi.Repositories.PropertyAmenityRepositories;

public interface IPropertyAmenityRepository
{
    Task<List<ResultPropertyAmenityByStatusTrueDto>> GetAllPropertyAmenityByStatusTrueAsync(int propertyId);
}