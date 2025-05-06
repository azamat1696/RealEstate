using RealEstateApi.Dto;
using RealEstateApi.Dto.ContactDtos;

namespace RealEstateApi.Repositories.ContactRepositories;

public interface IContactRepository
{
    Task<List<ResultContactDto>> GetAllContactAsync();
    Task<List<ResultLastFourContactDto>> GetLastFourContactAsync();
    void CreateContactAsync(CreateContactDto createContactDto);
    void DeleteContactAsync(int id);
    Task<GetByIdContactDto> GetByIdContactAsync(int id);
}