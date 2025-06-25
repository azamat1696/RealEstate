using RealEstateApi.Dto.AppUserDtos;

namespace RealEstateApi.Repositories.AppUserRepositories;

public interface IAppUserRepository
{
    Task <GetAppUserByProductIdDto> GetAppUsersByProductIdAsync(int productId);
}