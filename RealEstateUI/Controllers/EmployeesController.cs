using Microsoft.AspNetCore.Mvc;
using RealEstateUI.Dto.EmployeeDtos;

namespace RealEstateUI.Controllers;

public class EmployeesController : Controller
{
    private readonly IHttpClientFactory _clientFactory;
    public EmployeesController(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }
    public async Task<IActionResult> Index()
    {
        var client = _clientFactory.CreateClient();
        var response = await client.GetAsync("http://localhost:5059/api/Employees");
        if (response.IsSuccessStatusCode)
        {
            var employees = await response.Content.ReadFromJsonAsync<List<ResultEmployeeDto>>();
            return View(employees);
        }
        return View();
    }
}