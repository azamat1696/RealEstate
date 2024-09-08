using RealEstateApi.Dto.BottomGridDtos;

namespace RealEstateApi.Repositories.BottomGridRepository;

public interface IBottomGridRepository
{
    Task<List<ResultBottomGridDto>> GetAllBottomGridAsync();
    void CreateBottomGridAsync(CreateBottomGridDto createBottomGridDto);
    void DeleteBottomGridAsync(int id);
    Task UpdateBottomGridAsync(UpdateBottomGridDto updateBottomGridDto);
    Task<GetByIdBottomGridDto> GetByIdBottomGridAsync(int id);
}