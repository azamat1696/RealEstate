using Dapper;
using RealEstateApi.Dto;
using RealEstateApi.Dto.ProductDtos;
using RealEstateApi.Models.DapperContext;

namespace RealEstateApi.Repositories.ProductRepository;

public class ProductRepository : IProductRepository
{
    private readonly Context _context;
    public ProductRepository(Context context)
    {
        _context = context;
    }
    public async Task<List<ResultProductDto>> GetAllProductsAsync()
    {
        string query = "SELECT * FROM products";
        using (var connection = _context.CreateConnection())
        {
            var values = await connection.QueryAsync<ResultProductDto>(query);
            return values.ToList();
        }
    }
    public async Task<List<ResultProductWithCategoryDto>> GetAllProductsWithCategoryAsync()
    {
        string query = "SELECT *,CategoryName FROM products p LEFT JOIN categories c ON p.ProductCategory = c.CategoryId";
        using (var connection = _context.CreateConnection())
        {
            var values = await connection.QueryAsync<ResultProductWithCategoryDto>(query);
            return values.ToList();
        }
    }
    public async Task ProductDealOfTheDayStatusChangeToActive(int id)
    {
        string query = "UPDATE products SET DealOfTheDay = 1 WHERE ProductId = @id";
        var parameters = new DynamicParameters();
        parameters.Add("id", id);
        using (var connection = _context.CreateConnection())
        {
           await connection.ExecuteAsync(query, parameters);
        }
    }
    public async Task ProductDealOfTheDayStatusChangeToPassive(int id)
    {
        string query = "UPDATE products SET DealOfTheDay = 0 WHERE ProductId = @id";
        var parameters = new DynamicParameters();
        parameters.Add("id", id);
        using (var connection = _context.CreateConnection())
        {
           await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task<List<ResultLastFiveProductWithCategoryDto>> GetLastFiveProductsAsync()
    {
        string query = "SELECT *, CategoryName FROM products p \nLEFT JOIN categories c ON p.ProductCategory = c.CategoryId \nWHERE p.Type='Kiralık' ORDER BY p.ProductId DESC LIMIT 5";
        using (var connection = _context.CreateConnection())
        {
            var values = await connection.QueryAsync<ResultLastFiveProductWithCategoryDto>(query);
            return values.ToList();
        }
    }
    public async Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetProductAdvertsListByEmployeeIdAsync(int employeeId)
    {
        string query = "SELECT *,CategoryName FROM products p LEFT JOIN categories c ON p.ProductCategory = c.CategoryId WHERE p.EmployeeId = @employeeId";
        var parameters = new DynamicParameters();
        parameters.Add("employeeId", employeeId);
        using (var connection = _context.CreateConnection())
        {
            var values = await connection.QueryAsync<ResultProductAdvertListWithCategoryByEmployeeDto>(query, parameters);
            return values.ToList();
        }
    }
    public async Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetProductAdvertsActiveListByEmployeeIdAsync(int employeeId)
    {
        string query = "SELECT *,CategoryName FROM products p LEFT JOIN categories c ON p.ProductCategory = c.CategoryId WHERE p.EmployeeId = @employeeId AND p.ProductStatus = 1";
        var parameters = new DynamicParameters();
        parameters.Add("employeeId", employeeId);
        using (var connection = _context.CreateConnection())
        {
            var values = await connection.QueryAsync<ResultProductAdvertListWithCategoryByEmployeeDto>(query, parameters);
            return values.ToList();
        }
    }
    public async Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetProductAdvertsPassiveListByEmployeeIdAsync(int employeeId)
    {
        string query = "SELECT *,CategoryName FROM products p LEFT JOIN categories c ON p.ProductCategory = c.CategoryId WHERE p.EmployeeId = @employeeId AND p.ProductStatus = 0";
        var parameters = new DynamicParameters();
        parameters.Add("employeeId", employeeId);
        using (var connection = _context.CreateConnection())
        {
            var values = await connection.QueryAsync<ResultProductAdvertListWithCategoryByEmployeeDto>(query, parameters);
            return values.ToList();
        }
    }

    public async Task CreateProductAsync(CreateProductDto createProductDto)
    {
        string query = "INSERT INTO products (Title, Price,CoverImage,City,District,Address,Description,Type,ProductCategory,EmployeeId,DealOfTheDay,AdvertisementDate,ProductStatus) " +
                                     "VALUES (@Title, @Price, @CoverImage, @City, @District, @Address, @Description, @Type, @ProductCategory, @EmployeeId, @DealOfTheDay, @AdvertisementDate, @ProductStatus)";
        var parameters = new DynamicParameters();
        parameters.Add("@Title", createProductDto.Title);
        parameters.Add("@Price", createProductDto.Price);
        parameters.Add("@CoverImage", createProductDto.CoverImage);
        parameters.Add("@City", createProductDto.City);
        parameters.Add("@District", createProductDto.District);
        parameters.Add("@Address", createProductDto.Address);
        parameters.Add("@Description", createProductDto.Description);
        parameters.Add("@Type", createProductDto.Type);
        parameters.Add("@ProductCategory", createProductDto.ProductCategory);
        parameters.Add("@EmployeeId", createProductDto.EmployeeId);
        parameters.Add("@DealOfTheDay", createProductDto.DealOfTheDay);
        parameters.Add("@AdvertisementDate", createProductDto.AdvertisementDate);
        // Ensure the ProductStatus is set to true (1) by default
        createProductDto.ProductStatus = true; // Assuming you want to set it to active by default
        parameters.Add("@ProductStatus", createProductDto.ProductStatus ? 1 : 0);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters); 
        }
    }

    public async Task<GetProductByIdDto> GetProductById(int id)
    {
        string query = "SELECT *,CategoryName FROM products p LEFT JOIN categories c ON p.ProductCategory = c.CategoryId WHERE p.ProductId = @id";
        var parameters = new DynamicParameters();
        parameters.Add("id", id);
        using (var connection = _context.CreateConnection())
        {
            var values = await connection.QueryAsync<GetProductByIdDto>(query, parameters);
            return values.FirstOrDefault();
        }
    }
    public async Task<GetProductDetailsByIdDto> GetProductDetailsById(int id)
    {
        string query = "SELECT * FROM product_details WHERE ProductId = @id";
        var parameters = new DynamicParameters();
        parameters.Add("id", id);
        using (var connection = _context.CreateConnection())
        {
            var values = await connection.QueryAsync<GetProductDetailsByIdDto>(query, parameters);
            return values.FirstOrDefault();
        }
    }
}