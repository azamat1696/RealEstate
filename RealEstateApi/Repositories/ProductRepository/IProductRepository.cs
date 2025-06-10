using RealEstateApi.Dto.ProductDtos;

namespace RealEstateApi.Repositories.ProductRepository;

public interface IProductRepository
{
    Task<List<ResultProductDto>> GetAllProductsAsync();
    Task<List<ResultProductWithCategoryDto>> GetAllProductsWithCategoryAsync();
    
    void ProductDealOfTheDayStatusChangeToActive(int id);
    void ProductDealOfTheDayStatusChangeToPassive(int id);
    
    Task<List<ResultLastFiveProductWithCategoryDto>> GetLastFiveProductsAsync();
    Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetProductAdvertsListByEmployeeIdAsync(int employeeId);
    
}