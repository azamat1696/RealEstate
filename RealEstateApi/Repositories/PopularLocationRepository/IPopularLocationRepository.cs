using RealEstateApi.Dto.PopularLocationDtos;

namespace RealEstateApi.Repositories.PopularLocationRepository;

public interface IPopularLocationRepository
{
    Task<List<ResultPopularLocationDto>> GetAllPopularLocationAsync();
    void CreatePopularLocationAsync(CreatePopularLocationDto createPopularLocationDto);
    void DeletePopularLocationAsync(int id);
    Task UpdatePopularLocationAsync(UpdatePopularLocationDto updatePopularLocationDto);
    Task<GetByIdPopularLocationDto> GetByIdPopularLocationAsync(int id);
}