using Dapper;
using RealEstateApi.Models.DapperContext;

namespace RealEstateApi.Repositories.EstateAgentRepositories.DashboardRepositories.StatisticRepositories;

public class StatisticRepository : IStatisticRepository
{
    private readonly Context _context;
    public StatisticRepository(Context context)
    {
        _context = context;
    }
    
    public int ProductCountByEmployeeId(int employeeId)
    {
        string query = "SELECT COUNT(*) FROM products WHERE EmployeeId = @EmployeeId";
        var parameters = new DynamicParameters();
        parameters.Add("EmployeeId", employeeId);
        using (var connection = _context.CreateConnection())
        {
            var count = connection.QueryFirstOrDefault<int>(query, parameters);
            return count;
        }
    }

    public int ActiveProductCount(int employeeId)
    {
        var query = "SELECT COUNT(*) FROM products WHERE EmployeeId = @EmployeeId AND ProductStatus = 1";
        var parameters = new DynamicParameters();
        parameters.Add("EmployeeId", employeeId);
        using (var connection = _context.CreateConnection())
        {
            var count = connection.QueryFirstOrDefault<int>(query, parameters);
            return count;
        }
    }

    public int InactiveProductCount(int employeeId)
    {
         var query = "SELECT COUNT(*) FROM products WHERE EmployeeId = @EmployeeId AND ProductStatus = 0";
            var parameters = new DynamicParameters();
            parameters.Add("EmployeeId", employeeId);
            using (var connection = _context.CreateConnection())
            {
                var count = connection.QueryFirstOrDefault<int>(query, parameters);
                return count;
            }
    }

    public int AllProductCount(int employeeId)
    {
         var query = "SELECT COUNT(*) FROM products where EmployeeId = @EmployeeId";
         var parameters = new DynamicParameters();
         parameters.Add("EmployeeId", employeeId);
         
         using (var connection = _context.CreateConnection())
         {
             var value = connection.QueryFirstOrDefault<int>(query,parameters);
             return value;
         }
    }
}