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
    Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetProductAdvertsActiveListByEmployeeIdAsync(int employeeId);
    Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetProductAdvertsPassiveListByEmployeeIdAsync(int employeeId);
    Task CreateProductAsync(CreateProductDto createProductDto);
    
}