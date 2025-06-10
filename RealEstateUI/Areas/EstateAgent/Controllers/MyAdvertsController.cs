using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstateUI.Dto.ProductDtos;

namespace RealEstateUI.Areas.EstateAgent.Controllers;

[Area("EstateAgent")]
public class MyAdvertsController : Controller
{
    protected readonly IHttpClientFactory _httpClientFactory;
    
    public MyAdvertsController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    
    public async Task<IActionResult> Index(int employeeId)
    {
        employeeId = 1;
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("http://localhost:5059/api/Products/ProductAdvertsListByEmployee/"+employeeId);
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<List<ResultProductAdvertListWithCategoryByEmployeeDto>>(jsonData);
            return View(products);
        }
        return View();
    }
}