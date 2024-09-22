using Dapper;
using RealEstateApi.Dto.EmployeeDtos;
using RealEstateApi.Models.DapperContext;

namespace RealEstateApi.Repositories.EmployeeRespositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly Context _context;
    public EmployeeRepository(Context context)
    {
        _context = context;
    }
    public async Task<List<ResultEmployeeDto>> GetAllEmployeeAsync()
    {
        string query = "SELECT * FROM employee";
        using (var connection = _context.CreateConnection())
        {
            var result = await connection.QueryAsync<ResultEmployeeDto>(query);
            return result.ToList();
        }
    }

    public async void CreateEmployeeAsync(CreateEmployeeDto createEmployeeDto)
    {
       string query = "INSERT INTO employee (Name, Title, Mail, PhoneNumber, ImageUrl, Status) VALUES (@Name, @Title, @Mail, @PhoneNumber, @ImageUrl, @Status)";
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, createEmployeeDto);
        }
    }

    public async void DeleteEmployeeAsync(int id)
    {
       string query = "DELETE FROM employee WHERE EmployeeId = @EmployeeId";
       var parameters =new DynamicParameters();
         parameters.Add("@EmployeeId", id);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task UpdateEmployeeAsync(UpdateEmployeeDto updateEmployeeDto)
    {
       string query = "UPDATE employee SET Name = @Name, Title = @Title, Mail = @Mail, PhoneNumber = @PhoneNumber, ImageUrl = @ImageUrl, Status = @Status WHERE EmployeeId = @EmployeeId";
       var parameters = new DynamicParameters();
        parameters.Add("@Name", updateEmployeeDto.Name);
        parameters.Add("@Title", updateEmployeeDto.Title);
        parameters.Add("@Mail", updateEmployeeDto.Mail);
        parameters.Add("@PhoneNumber", updateEmployeeDto.PhoneNumber);
        parameters.Add("@ImageUrl", updateEmployeeDto.ImageUrl);
        parameters.Add("@Status", updateEmployeeDto.Status);
        parameters.Add("@EmployeeId", updateEmployeeDto.EmployeeId);
        
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, updateEmployeeDto);
        }
    }

    public async Task<GetBydEmployeeDto> GetByIdEmployeeAsync(int id)
    {
        string query = "SELECT * FROM employee WHERE EmployeeId = @EmployeeId";
        var parameters = new DynamicParameters();
        parameters.Add("@EmployeeId", id);
        using (var connection = _context.CreateConnection())
        {
            return await connection.QueryFirstOrDefaultAsync<GetBydEmployeeDto>(query, parameters);
        }
    }
}