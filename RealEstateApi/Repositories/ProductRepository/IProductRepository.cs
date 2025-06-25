using RealEstateApi.Dto.ProductDtos;

namespace RealEstateApi.Repositories.ProductRepository;

public interface IProductRepository
{
    Task<List<ResultProductDto>> GetAllProductsAsync();
    Task<List<ResultProductWithCategoryDto>> GetAllProductsWithCategoryAsync();
    
    Task ProductDealOfTheDayStatusChangeToActive(int id);
    Task ProductDealOfTheDayStatusChangeToPassive(int id);
    
    Task<List<ResultLastFiveProductWithCategoryDto>> GetLastFiveProductsAsync();
    Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetProductAdvertsListByEmployeeIdAsync(int employeeId);
    Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetProductAdvertsActiveListByEmployeeIdAsync(int employeeId);
    Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetProductAdvertsPassiveListByEmployeeIdAsync(int employeeId);
    Task CreateProductAsync(CreateProductDto createProductDto);
    Task<GetProductByIdDto> GetProductById(int id);
    Task<GetProductDetailsByIdDto> GetProductDetailsById(int id);
    
    
    
}