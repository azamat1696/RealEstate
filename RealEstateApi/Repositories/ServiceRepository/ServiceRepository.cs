using Dapper;
using RealEstateApi.Dto.ServiceDtos;
using RealEstateApi.Models.DapperContext;

namespace RealEstateApi.Repositories.ServiceRepository;

public class ServiceRepository : IServiceRepository
{
  private readonly Context _context;
  public ServiceRepository(Context context)
  {
    _context = context;
  }

  public async Task<List<ResultServiceDto>> GetAllServiceAsync()
  {
     string query = "SELECT * FROM service";
     using (var connection = _context.CreateConnection())
     {
       var values = await connection.QueryAsync<ResultServiceDto>(query);
       return values.ToList();
     }
  }

  public async void CreateServiceAsync(CreateServiceDto createServiceDto)
  {
     string query = "INSERT INTO service (ServiceName, ServiceStatus) VALUES (@ServiceName, @ServiceStatus)";
      var parameters = new DynamicParameters();
      parameters.Add("ServiceName", createServiceDto.ServiceName);
      parameters.Add("ServiceStatus", createServiceDto.ServiceStatus);
      using (var connection = _context.CreateConnection())
      {
        await connection.ExecuteAsync(query, parameters);
      }
  }

  public async void DeleteServiceAsync(int id)
  {
     string query = "DELETE FROM service WHERE ServiceId = @ServiceId";
      var parameters = new DynamicParameters();
      parameters.Add("@ServiceId", id);
      using (var connection = _context.CreateConnection())
      {
        await connection.ExecuteAsync(query, parameters);
      }
  }

  public async Task UpdateServiceAsync(UpdateServiceDto updateServiceDto)
  {
    string query = "UPDATE service SET ServiceName = @ServiceName, ServiceStatus = @ServiceStatus WHERE ServiceId = @ServiceId";
    var parameters = new DynamicParameters();
    parameters.Add("@ServiceName", updateServiceDto.ServiceName);
    parameters.Add("@ServiceStatus", updateServiceDto.ServiceStatus);
    parameters.Add("@ServiceId", updateServiceDto.ServiceId);
    using (var connection = _context.CreateConnection())
    {
      await connection.ExecuteAsync(query, parameters);
    }
    
  }

  public async Task<GetByIdServiceDto> GetByIdServiceAsync(int id)
  {
    string query = "SELECT * FROM service WHERE ServiceId = @ServiceId";
    var parameters = new DynamicParameters();
    parameters.Add("@ServiceId", id);
    using (var connection = _context.CreateConnection())
    {
      return await connection.QueryFirstOrDefaultAsync<GetByIdServiceDto>(query, parameters);
    }
  }
}