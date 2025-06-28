using Microsoft.AspNetCore.Mvc;
using RealEstateUI.Dto.CategoryDtos;

namespace RealEstateUI.ViewComponents.HomePage;

public class _DefaultFeatureComponentPartial:ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;
    public _DefaultFeatureComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("http://localhost:5059/api/Categories");
        if (response.IsSuccessStatusCode)
        {
            var products = await response.Content.ReadFromJsonAsync<List<ResultCategoryDto>>();
            return View(products);
        }
        return View(new List<ResultCategoryDto>());
    }
}