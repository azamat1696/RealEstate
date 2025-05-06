using Dapper;
using RealEstateApi.Dto.ContactDtos;
using RealEstateApi.Models.DapperContext;

namespace RealEstateApi.Repositories.ContactRepositories;

public class ContactRepository:IContactRepository
{
    private readonly Context _context;
    public ContactRepository(Context context)
    {
        _context = context;
    }
    
    public async Task<List<ResultContactDto>> GetAllContactAsync()
    {
        string query = "SELECT * FROM contact";
        using (var connection = _context.CreateConnection())
        {
            var result = await connection.QueryAsync<ResultContactDto>(query);
            return result.ToList();
        }
    }

    public async Task<List<ResultLastFourContactDto>> GetLastFourContactAsync()
    {
        string query = "SELECT * FROM contact ORDER BY SendDate DESC LIMIT 4";
        using (var connection = _context.CreateConnection())
        {
          var result = await connection.QueryAsync<ResultLastFourContactDto>(query);    
          return result.ToList();
        }
    }

    public async void CreateContactAsync(CreateContactDto createContactDto)
    {
        string query = "INSERT INTO contact (Name, Subject, Email, Message, SendDate) VALUES (@Name, @Subject, @Email, @Message, @SendDate)";
        using (var connection = _context.CreateConnection())
        {
           await connection.ExecuteAsync(query, createContactDto);
        }
    }

    public async void DeleteContactAsync(int id)
    {
        string query = "DELETE FROM contact WHERE ContactId = @Id";
        var parameters = new DynamicParameters();
        parameters.Add("@Id", id);
        using (var connection = _context.CreateConnection())
        {
           await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task<GetByIdContactDto> GetByIdContactAsync(int id)
    {
        string query = "SELECT * FROM contact WHERE ContactId = @Id";
        var parameters = new DynamicParameters();
        parameters.Add("@Id", id);
        using (var connection = _context.CreateConnection())
        {
            var result = await connection.QueryFirstOrDefaultAsync<GetByIdContactDto>(query, parameters);
            if (result == null)
            {
                return null;
            }
            return result;
        } 
    }
}