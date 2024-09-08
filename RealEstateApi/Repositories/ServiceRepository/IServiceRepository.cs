using RealEstateApi.Dto.ServiceDtos;

namespace RealEstateApi.Repositories.ServiceRepository;

public interface IServiceRepository
{
    Task<List<ResultServiceDto>> GetAllServiceAsync();
    void CreateServiceAsync(CreateServiceDto createServiceDto);
    void DeleteServiceAsync(int id);
    Task UpdateServiceAsync(UpdateServiceDto updateServiceDto);
    Task<GetByIdServiceDto> GetByIdServiceAsync(int id);
}