using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstateUI.Dto.ProductDtos;

namespace RealEstateUI.Controllers;

public class PropertyController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public PropertyController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("http://localhost:5059/api/Products/ProductsWithCategory");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
            return View(products);
        }
        return View();
    }
    public async Task<IActionResult> Detail(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync($"http://localhost:5059/api/Products/{id}");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<ResultProductWithCategoryDto>(jsonData);
            return View(product);
        }

        return View(new ResultProductWithCategoryDto());
         
    }
}