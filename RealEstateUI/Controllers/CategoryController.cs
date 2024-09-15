using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstateUI.Dto.CategoryDtos;

namespace RealEstateUI.Controllers;

public class CategoryController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    public CategoryController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("http://localhost:5059/api/Categories");
        if (response.IsSuccessStatusCode)
        {
           var jsonData = await response.Content.ReadAsStringAsync();
           var categories = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
           return View(categories);
           
        }
        return View();
    }
}