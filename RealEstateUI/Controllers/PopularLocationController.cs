using Microsoft.AspNetCore.Mvc;
using System.Text;
using Newtonsoft.Json;
using RealEstateUI.Dto.PopularLocationDtos;

namespace RealEstateUI.Controllers;

public class PopularLocationController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    public PopularLocationController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("http://localhost:5059/api/PopularLocation");
        if (response.IsSuccessStatusCode)
        {
           var jsonData = await response.Content.ReadAsStringAsync();
           var result = JsonConvert.DeserializeObject<List<ResultPopularLocationDto>>(jsonData);
           return View(result);
           
        }
        return View();
    }
    [HttpGet]
    public IActionResult CreatePopularLocation()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> CreatePopularLocation(CreatePopularLocationDto createPopularLocationDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(createPopularLocationDto);
        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var response = await client.PostAsync("http://localhost:5059/api/PopularLocation", content);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View(createPopularLocationDto);
    }
    public async Task<IActionResult> DeletePopularLocation(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.DeleteAsync($"http://localhost:5059/api/PopularLocation/{id}");
        if (response.IsSuccessStatusCode)
        {
            
            return RedirectToAction("Index");
        }
        return NotFound();
    }
    [HttpGet]
    public async Task<IActionResult> UpdatePopularLocation(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync($"http://localhost:5059/api/PopularLocation/{id}");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<UpdatePopularLocationDto>(jsonData);
            return View(result);
        }
        return NotFound();
    }
    [HttpPost]
    public async Task<IActionResult> UpdatePopularLocation(UpdatePopularLocationDto updatePopularLocationDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(updatePopularLocationDto);
        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var response = await client.PutAsync("http://localhost:5059/api/PopularLocation", content);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View(updatePopularLocationDto);
    }
}