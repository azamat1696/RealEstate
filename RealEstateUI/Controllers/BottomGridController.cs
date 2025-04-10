using Microsoft.AspNetCore.Mvc;
using System.Text;
using Newtonsoft.Json;
using RealEstateUI.Dto.BottomGridDtos;

namespace RealEstateUI.Controllers;

public class BottomGridController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    public BottomGridController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("http://localhost:5059/api/BottomGrid");
        if (response.IsSuccessStatusCode)
        {
           var jsonData = await response.Content.ReadAsStringAsync();
           var result = JsonConvert.DeserializeObject<List<ResultBottomGridDto>>(jsonData);
           return View(result);
           
        }
        return View();
    }
    [HttpGet]
    public IActionResult CreateBottomGrid()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> CreateBottomGrid(CreateBottomGridDto createBottomGridDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(createBottomGridDto);
        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var response = await client.PostAsync("http://localhost:5059/api/BottomGrid", content);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View(createBottomGridDto);
    }
    public async Task<IActionResult> DeleteBottomGrid(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.DeleteAsync($"http://localhost:5059/api/BottomGrid/{id}");
        if (response.IsSuccessStatusCode)
        {
            
            return RedirectToAction("Index");
        }
        return NotFound();
    }
    [HttpGet]
    public async Task<IActionResult> UpdateBottomGrid(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync($"http://localhost:5059/api/BottomGrid/{id}");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<UpdateBottomGridDto>(jsonData);
            return View(result);
        }
        return NotFound();
    }
    [HttpPost]
    public async Task<IActionResult> UpdateBottomGrid(UpdateBottomGridDto updateBottomGridDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(updateBottomGridDto);
        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var response = await client.PutAsync("http://localhost:5059/api/BottomGrid", content);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View(updateBottomGridDto);
    }
}