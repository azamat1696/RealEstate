using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using RealEstateUI.Dto.CategoryDtos;
using RealEstateUI.Dto.ProductDtos;

namespace RealEstateUI.Controllers;

public class ProductController : Controller
{
    protected readonly IHttpClientFactory _httpClientFactory;
    
    public ProductController(IHttpClientFactory httpClientFactory)
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
    [HttpGet]
    public async Task<IActionResult> CreateProduct()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("http://localhost:5059/api/Categories");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var categories = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
            List<SelectListItem> categoryList = (from x in categories.ToList()
                    select new SelectListItem
                    {
                        Text = x.CategoryName,
                        Value = x.CategoryId.ToString()
                    }
                ).ToList();
            ViewBag.CategoryList = categoryList;
        }
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
    {
        var client = _httpClientFactory.CreateClient();
        var json = JsonConvert.SerializeObject(createProductDto);
        var data = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await client.PostAsync("http://localhost:5059/api/Products/CreateProduct", data);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }
}