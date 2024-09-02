using System.Data;
using MySqlConnector;

namespace RealEstateApi.Models.DapperContext;

public class Context
{
    private readonly IConfiguration _config;
    private readonly string _connectionString;
    public Context(IConfiguration config)
    {
        _config = config;
        _connectionString = _config.GetConnectionString("connection");
    }
    public IDbConnection CreateConnection() => new MySqlConnection(_connectionString);
}