using Dapper;
using RealEstateApi.Models.DapperContext;

namespace RealEstateApi.Repositories.StatisticsRepositories;

public class StatisticsRepository : IStatisticsRepository
{
    private readonly Context _context;
    public StatisticsRepository(Context context)
    {
        _context = context;
    }
    public int CategoryCount()
    {
        string query = "SELECT COUNT(*) FROM categroies";
        using (var connection = _context.CreateConnection())
        {
            var result = connection.QueryFirstOrDefault<int>(query);
            return result;
        }
    }

    public int ActiveCategoryCount()
    {
        string query = "SELECT COUNT(*) FROM categroies where CategoryStatus = 1";
        using (var connection = _context.CreateConnection())
        {
            var result = connection.QueryFirstOrDefault<int>(query);
            return result;
        }
    }

    public int InactiveCategoryCount()
    {
        throw new NotImplementedException();
    }

    public int PropertyCount()
    {
        throw new NotImplementedException();
    }

    public int ApartmentCount()
    {
        throw new NotImplementedException();
    }

    public string EmployeeWithMostProperties()
    {
        throw new NotImplementedException();
    }

    public string CategoryWithMostProperties()
    {
        throw new NotImplementedException();
    }

    public decimal AveragePropertyByRentPrice()
    {
        throw new NotImplementedException();
    }

    public decimal AveragePropertyBySalePrice()
    {
        throw new NotImplementedException();
    }

    public string CityNameByMaxProductCount()
    {
        throw new NotImplementedException();
    }

    public int DifferentCityCount()
    {
        throw new NotImplementedException();
    }

    public decimal LastPropertyPrice()
    {
        throw new NotImplementedException();
    }

    public string NewestBuildingYear()
    {
        throw new NotImplementedException();
    }

    public string OldestBuildingYear()
    {
        throw new NotImplementedException();
    }

    public int AverageRoomCount()
    {
        throw new NotImplementedException();
    }

    public int ActiveEmployeeCount()
    {
        throw new NotImplementedException();
    }
}