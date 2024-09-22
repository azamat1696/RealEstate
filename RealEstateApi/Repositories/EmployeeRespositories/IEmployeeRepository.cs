using RealEstateApi.Dto.EmployeeDtos;

namespace RealEstateApi.Repositories.EmployeeRespositories;

public interface IEmployeeRepository
{
    Task<List<ResultEmployeeDto>> GetAllEmployeeAsync();
    void CreateEmployeeAsync(CreateEmployeeDto createEmployeeDto);
    void DeleteEmployeeAsync(int id);
    Task UpdateEmployeeAsync(UpdateEmployeeDto updateEmployeeDto);
    Task<GetBydEmployeeDto> GetByIdEmployeeAsync(int id);
}