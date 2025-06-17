using RealEstateApi.Dto.ChartDtos;

namespace RealEstateApi.Repositories.EstateAgentRepositories.DashboardRepositories.ChartRepositories;

public interface IChartRepository
{
    Task<List<ResultChartDto>> GetFiveCityChartData();
}