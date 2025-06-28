using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstateUI.Dto.PropertyAmenityDtos;

namespace RealEstateUI.ViewComponents.PropertySingle;

public class _PropertyAmenityByStatusTrueByPropertyIdComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _clientFactory;
    public _PropertyAmenityByStatusTrueByPropertyIdComponentPartial(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }
    public async Task<IViewComponentResult> InvokeAsync(int productId)
    {
        var client = _clientFactory.CreateClient();
        var response = await client.GetAsync($"http://localhost:5059/api/PropertyAmenities?propertyId={productId}");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var appUser = JsonConvert.DeserializeObject<List<ResultPropertyAmenityByStatusTrueDto>>(jsonData);
            return View(appUser);
        }
        return View(new List<ResultPropertyAmenityByStatusTrueDto>());
    }
}