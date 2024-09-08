using RealEstateApi.Dto.WhoWeAreDetailDtos;

namespace RealEstateApi.Repositories.WhoWeAreDetailRepository;

public interface IWhoWeAreDetailRepository
{
    Task<List<ResultWhoWeAreDetailDto>> GetAllWhoWeAreDetailAsync();
    void CreateWhoWeAreDetailAsync(CreateWhoWeAreDetailDto createWhoWeAreDetailDto);
    void DeleteWhoWeAreDetailAsync(int id);
    Task UpdateWhoWeAreDetailAsync(UpdateWhoWeAreDetailDto updateWhoWeAreDetailDto);
    Task<GetByIdWhoWeAreDetailDto> GetByIdWhoWeAreDetailAsync(int id);
}