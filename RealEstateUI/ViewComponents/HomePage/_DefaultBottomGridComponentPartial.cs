using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstateUI.Dto.BottomGridDtos;

namespace RealEstateUI.ViewComponents.HomePage;

public class _DefaultBottomGridComponentPartial: ViewComponent
{
    protected readonly IHttpClientFactory _httpClientFactory;

    public _DefaultBottomGridComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("http://localhost:5059/api/BottomGrid");
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadAsStringAsync();
            var bottomGrid = JsonConvert.DeserializeObject<List<ResultBottomGridDto>>(result);
            return View(bottomGrid);
        }
        return View();
    }
}