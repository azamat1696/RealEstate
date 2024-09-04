using RealEstateApi.Dto.ProductDtos;

namespace RealEstateApi.Repositories.ProductRepository;

public interface IProductRepository
{
    Task<List<ResultProductDto>> GetAllProductsAsync();
    Task<List<ResultProductWithCategoryDto>> GetAllProductsWithCategoryAsync();
}