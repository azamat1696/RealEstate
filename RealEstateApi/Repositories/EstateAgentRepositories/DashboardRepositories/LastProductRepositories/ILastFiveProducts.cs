using RealEstateApi.Dto.ProductDtos;

namespace RealEstateApi.Repositories.EstateAgentRepositories.DashboardRepositories.LastProductRepositories;

public interface ILastFiveProducts
{
    Task<List<ResultLastFiveProductWithCategoryDto>> GetLastFiveProductsAsync(int employeeId);
}