using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstateUI.Dto.EmployeeDtos;

namespace RealEstateUI.Controllers;

public class EmployeesController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    public EmployeesController(IHttpClientFactory clientFactory)
    {
        _httpClientFactory = clientFactory;
    }
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("http://localhost:5059/api/Employees");
        if (response.IsSuccessStatusCode)
        {
            var employees = await response.Content.ReadFromJsonAsync<List<ResultEmployeeDto>>();
            return View(employees);
        }
        return View();
    }
    [HttpGet]
    public IActionResult CreateEmployees()
    {
        return  View();
    }
    [HttpPost]
    public async Task<IActionResult> CreateEmployees(CreateEmployeeDto createEmployeeDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(createEmployeeDto);
        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var response = await client.PostAsync("http://localhost:5059/api/Employees", content);
        if (response.IsSuccessStatusCode)
        { 
            return RedirectToAction("Index");
        }
        return View(createEmployeeDto);
    }   
}