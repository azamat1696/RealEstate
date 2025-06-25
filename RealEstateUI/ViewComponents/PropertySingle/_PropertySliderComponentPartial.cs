using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstateUI.Dto.ProductImageDtos;
using RealEstateUI.Services;

namespace RealEstateUI.ViewComponents.EstateAgent;

public class _PropertySliderComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _clientFactory;
    public _PropertySliderComponentPartial(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }
    public async Task<IViewComponentResult> InvokeAsync(int productId)
    {
        var client = _clientFactory.CreateClient();
        var imagesResponse = await client.GetAsync($"http://localhost:5059/api/ProductImages?productId={productId}");
        if (imagesResponse.IsSuccessStatusCode)
        {
            var imagesJsonData = await imagesResponse.Content.ReadAsStringAsync();
            var productImages = JsonConvert.DeserializeObject<List<PropertyImageDto>>(imagesJsonData);
            return View(productImages);
         }
        return View();
    }
}