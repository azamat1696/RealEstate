using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstateUI.Dto.ContactDtos;

namespace RealEstateUI.ViewComponents.Dashboard;

public class _DashboardLastFourMessageComponentPartial : ViewComponent
{
    protected readonly IHttpClientFactory _httpClientFactory;
    public _DashboardLastFourMessageComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("http://localhost:5059/api/Contacts/LastFourContact");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var contacts = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);
            return View(contacts);
        }
        return View();
    }
}