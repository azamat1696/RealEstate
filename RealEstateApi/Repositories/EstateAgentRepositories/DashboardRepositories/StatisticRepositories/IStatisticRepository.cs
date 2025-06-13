namespace RealEstateApi.Repositories.EstateAgentRepositories.DashboardRepositories.StatisticRepositories;

public interface IStatisticRepository
{
    int ProductCountByEmployeeId(int employeeId);
    int ActiveProductCount(int employeeId);
    int InactiveProductCount(int employeeId);
    int AllProductCount(int employeeId);
}