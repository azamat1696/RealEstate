using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using RealEstateUI.Dto.CategoryDtos;
using RealEstateUI.Dto.ProductDtos;
using RealEstateUI.Services;

namespace RealEstateUI.Areas.EstateAgent.Controllers;

[Area("EstateAgent")]
public class MyAdvertsController : Controller
{
    protected readonly IHttpClientFactory _httpClientFactory;
    protected readonly ILoginService _loginService;
    
    public MyAdvertsController(IHttpClientFactory httpClientFactory, ILoginService loginService)
    {
        _loginService = loginService;
        _httpClientFactory = httpClientFactory;
    }
    
    public async Task<IActionResult> ActiveAdverts()
    {
        var employeeId = _loginService.GetUserId;
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("http://localhost:5059/api/Products/ProductAdvertsActiveListByEmployee/"+employeeId);
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<List<ResultProductAdvertListWithCategoryByEmployeeDto>>(jsonData);
            return View(products);
        }
        return View(new List<ResultProductAdvertListWithCategoryByEmployeeDto>());
    }
    public async Task<IActionResult> PassiveAdverts()
    {
        var employeeId = _loginService.GetUserId;
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("http://localhost:5059/api/Products/ProductAdvertsPassiveListByEmployee/"+employeeId);
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<List<ResultProductAdvertListWithCategoryByEmployeeDto>>(jsonData);
            return View(products);
        } 
        return View(new List<ResultProductAdvertListWithCategoryByEmployeeDto>());
    }
    [HttpGet]
    public  async Task<IActionResult> CreateAdvert()
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
    public async Task<IActionResult> CreateAdvert(CreateProductDto createProductDto)
    {
        createProductDto.DealOfTheDay = false;
        createProductDto.AdvertisementDate = DateTime.Now;
        createProductDto.ProductStatus = true; // Assuming you want to set it to active by default
        createProductDto.EmployeeId = int.Parse(_loginService.GetUserId); //Convert.ToInt32(_loginService.GetUserId); // convet to int ;
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