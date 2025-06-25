using RealEstateApi.Dto.ProductImageDtos;

namespace RealEstateApi.Repositories.ProductImageRepositories;

public interface IProductImageRepository
{
    Task<List<GetProductImageByProductIdDto>> GetProductImageByProductId(int productId);
}