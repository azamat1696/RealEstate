using Microsoft.AspNetCore.Mvc;
using RealEstateApi.Dto.EmployeeDtos;
using RealEstateApi.Repositories.EmployeeRespositories;

namespace RealEstateApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeesController : Controller
{
    private readonly IEmployeeRepository _employeeRepository;
    public EmployeesController(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }
    [HttpGet]
    public async Task<IActionResult> EmployeeList()
    {
        var employees = await _employeeRepository.GetAllEmployeeAsync();
        return Ok(employees);
    }
    [HttpPost]
    public async Task<IActionResult> CreateEmployee(CreateEmployeeDto createEmployeeDto)
    {
         _employeeRepository.CreateEmployeeAsync(createEmployeeDto);
        return Ok("Employee Created");
    }
    [HttpDelete("{employeeId}")]
    public async Task<IActionResult> DeleteEmployee(int employeeId)
    {
        _employeeRepository.DeleteEmployeeAsync(employeeId);
        return Ok("Employee Deleted");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateEmployee(UpdateEmployeeDto updateEmployeeDto)
    {
        await _employeeRepository.UpdateEmployeeAsync(updateEmployeeDto);
        return Ok("Employee Updated");
    }
    [HttpGet("{employeeId}")]
    public async Task<IActionResult> GetByIdEmployee(int employeeId)
    {
        var employee = await _employeeRepository.GetByIdEmployeeAsync(employeeId);
        return Ok(employee);
    }
}