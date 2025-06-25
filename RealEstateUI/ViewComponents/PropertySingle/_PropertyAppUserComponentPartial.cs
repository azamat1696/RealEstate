using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstateUI.Dto.AppUserDtos;
using RealEstateUI.Dto.ProductImageDtos;
using RealEstateUI.Services;

namespace RealEstateUI.ViewComponents.PropertySingle;

public class _PropertyAppUserComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _clientFactory;
    public _PropertyAppUserComponentPartial(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }
    public async Task<IViewComponentResult> InvokeAsync(int productId)
    {
        var client = _clientFactory.CreateClient();
        var response = await client.GetAsync($"http://localhost:5059/api/AppUsers?productId={productId}");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var appUser = JsonConvert.DeserializeObject<GetAppUserByProductIdDto>(jsonData);
            return View(appUser);
         }
        return View(new GetAppUserByProductIdDto());
    }
}