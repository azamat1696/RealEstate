using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstateUI.Dto.ProductDtos;

namespace RealEstateUI.ViewComponents.Dashboard;

public class _DashboardLastFiveProductComponentPartial : ViewComponent
{
    protected readonly IHttpClientFactory _httpClientFactory;
    public _DashboardLastFiveProductComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("http://localhost:5059/api/Products/LastFiveProductList");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<List<ResultLastFiveProductWithCategoryDto>>(jsonData);
            return View(products);
        }
        return View();
    }
}