using Microsoft.AspNetCore.Mvc;
using System.Text;
using Newtonsoft.Json;
using RealEstateUI.Dto.ServiceDtos;

namespace RealEstateUI.Controllers;

public class ServiceController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    public ServiceController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("http://localhost:5059/api/Services");
        if (response.IsSuccessStatusCode)
        {
           var jsonData = await response.Content.ReadAsStringAsync();
           var result = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData);
           return View(result);
           
        }
        return View();
    }
    [HttpGet]
    public IActionResult CreateService()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> CreateService(CreateServiceDto createServiceDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(createServiceDto);
        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var response = await client.PostAsync("http://localhost:5059/api/Services", content);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View(createServiceDto);
    }
    public async Task<IActionResult> DeleteService(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.DeleteAsync($"http://localhost:5059/api/Services/{id}");
        if (response.IsSuccessStatusCode)
        {
            
            return RedirectToAction("Index");
        }
        return NotFound();
    }
    [HttpGet]
    public async Task<IActionResult> UpdateService(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync($"http://localhost:5059/api/Services/{id}");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<UpdateServiceDto>(jsonData);
            return View(result);
        }
        return NotFound();
    }
    [HttpPost]
    public async Task<IActionResult> UpdateService(UpdateServiceDto updateServiceDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(updateServiceDto);
        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var response = await client.PutAsync("http://localhost:5059/api/Services", content);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View(updateServiceDto);
    }
}