using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstateUI.Dto.EsateAgentDtos;

namespace RealEstateUI.ViewComponents.EstateAgent.EstateAgentNavbar;

public class _EstateAgentNavbarMessageComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;
    public _EstateAgentNavbarMessageComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("http://localhost:5059/api/EstateAgentChart");
        if (response.IsSuccessStatusCode)
        { 
               var jsonData = await response.Content.ReadAsStringAsync();
               var values = JsonConvert.DeserializeObject<List<ResultEstateAgentDashboardChartDto>>(jsonData);
               return View(values);
        }
        return View();
    }
}