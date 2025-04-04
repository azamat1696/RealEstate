using Microsoft.AspNetCore.Mvc;
using System.Text;
using Newtonsoft.Json;
using RealEstateUI.Dto.WhoWeAreDtos;

namespace RealEstateUI.Controllers;

public class WhoWeAreController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    public WhoWeAreController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("http://localhost:5059/api/WhoWeAreDetail");
        if (response.IsSuccessStatusCode)
        {
           var jsonData = await response.Content.ReadAsStringAsync();
           var result = JsonConvert.DeserializeObject<List<ResultWhoWeAreDto>>(jsonData);
           return View(result);
           
        }
        return View();
    }
    [HttpGet]
    public IActionResult CreateWhoWeAre()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> CreateWhoWeAre(CreateWhoWeAreDto createWhoWeAreDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(createWhoWeAreDto);
        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var response = await client.PostAsync("http://localhost:5059/api/WhoWeAreDetail", content);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View(createWhoWeAreDto);
    }
    public async Task<IActionResult> DeleteWhoWeAre(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.DeleteAsync($"http://localhost:5059/api/WhoWeAreDetail/{id}");
        if (response.IsSuccessStatusCode)
        {
            
            return RedirectToAction("Index");
        }
        return NotFound();
    }
    [HttpGet]
    public async Task<IActionResult> UpdateWhoWeAre(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync($"http://localhost:5059/api/WhoWeAreDetail/{id}");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<UpdateWhoWeAreDto>(jsonData);
            return View(result);
        }
        return NotFound();
    }
    [HttpPost]
    public async Task<IActionResult> UpdateWhoWeAre(UpdateWhoWeAreDto updateWhoWeAreDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(updateWhoWeAreDto);
        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var response = await client.PutAsync("http://localhost:5059/api/WhoWeAreDetail", content);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View(updateWhoWeAreDto);
    }
}