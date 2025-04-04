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
        string query = "SELECT COUNT(*) FROM categories";
        using (var connection = _context.CreateConnection())
        {
            var result = connection.QueryFirstOrDefault<int>(query);
            return result;
        }
    }

    public int ActiveCategoryCount()
    {
        string query = "SELECT COUNT(*) FROM categories where CategoryStatus = 1";
        using (var connection = _context.CreateConnection())
        {
            var result = connection.QueryFirstOrDefault<int>(query);
            return result;
        }
    }

    public int InactiveCategoryCount()
    {
        string query = "SELECT COUNT(*) FROM categories where CategoryStatus = 0";
        using (var connection = _context.CreateConnection())
        {
            var result = connection.QueryFirstOrDefault<int>(query);
            return result;
        }
    }

    public int PropertyCount()
    {
        string query = "SELECT COUNT(*) FROM products";
        using (var connection = _context.CreateConnection())
        {
            var result = connection.QueryFirstOrDefault<int>(query);
            return result;
        }
    }

    public int ApartmentCount()
    {
        string query = "SELECT COUNT(*) FROM products where Title LIKE '%Daire%'";
        using (var connection = _context.CreateConnection())
        {
            var result = connection.QueryFirstOrDefault<int>(query);
            return result;
        }
    }

    public string? EmployeeWithMostProperties()
    {
        string query = "select Name,count(*) from products inner join employee on products.EmployeeId = employee.EmployeeId GROUP BY Name ORDER BY count(*) desc limit 1";
        using (var connection = _context.CreateConnection())
        {
            var result = connection.QueryFirstOrDefault<string>(query);
            return result;
        }
    }

    public string? CategoryWithMostProperties()
    {
        string query = "select CategoryName from products inner join categories on products.ProductCategory = categories.CategoryID GROUP BY ProductCategory order by  COUNT(*) desc limit 1";
        using (var connection = _context.CreateConnection())
        {
            var result = connection.QueryFirstOrDefault<string>(query);
            return result;
        }
    }

    public decimal AveragePropertyByRentPrice()
    {
        string query = "SELECT AVG(Price) FROM products WHERE Type = 'Kiralık'";
        using (var connection = _context.CreateConnection())
        {
            var result = connection.QueryFirstOrDefault<decimal>(query);
            return result;
        }
    }

    public decimal AveragePropertyBySalePrice()
    {
        string query = "SELECT AVG(Price) FROM products WHERE Type = 'Satılık'";
        using (var connection = _context.CreateConnection())
        {
            var result = connection.QueryFirstOrDefault<decimal>(query);
            return result;
        }
    }

    public string? CityNameByMaxProductCount()
    {
        string query = "select City from products group by City order by  count(*) desc limit 1";
        using (var connection = _context.CreateConnection())
        {
            var result = connection.QueryFirstOrDefault<string>(query);
            return result;
        }
    }

    public int DifferentCityCount()
    {
        string query = "select count(DISTINCT City) from products";
        using (var connection = _context.CreateConnection())
        {
            var result = connection.QueryFirstOrDefault<int>(query);
            return result;
        }
    }

    public decimal LastPropertyPrice()
    {
        string query = "select Price from products order by ProductId desc limit 1";
        using (var connection = _context.CreateConnection())
        {
            var result = connection.QueryFirstOrDefault<decimal>(query);
            return result;
        }
    }

    public string? NewestBuildingYear()
    {
        string query = "select BuildYear from product_details order by BuildYear desc limit 1";
        using (var connection = _context.CreateConnection())
        {
            var result = connection.QueryFirstOrDefault<string>(query);
            return result;
        }
    }

    public string? OldestBuildingYear()
    {
        string query = "select BuildYear from product_details order by BuildYear asc limit 1";
        using (var connection = _context.CreateConnection())
        {
            var result = connection.QueryFirstOrDefault<string>(query);
            return result;
        }
    }

    public int AverageRoomCount()
    {
        string query = "SELECT AVG(RoomCount) FROM product_details";
        using (var connection = _context.CreateConnection())
        {
            var result = connection.QueryFirstOrDefault<int>(query);
            return result;
        }
    }

    public int ActiveEmployeeCount()
    {
        string query = "SELECT COUNT(*) FROM employee WHERE Status = 1";
        using (var connection = _context.CreateConnection())
        {
            var result = connection.QueryFirstOrDefault<int>(query);
            return result;
        }
    }
}