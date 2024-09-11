using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstateUI.Dto.PopularLocationDtos;

namespace RealEstateUI.ViewComponents.HomePage;

public class _DefaultProductListExploreCitiesComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _clientFactory;
    public _DefaultProductListExploreCitiesComponentPartial(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }
     public async Task<IViewComponentResult> InvokeAsync()
     {
         var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:5059/api/PopularLocation");
            if (response.IsSuccessStatusCode)
            {
                 var jsonData = await response.Content.ReadAsStringAsync();
                    var popularLocations = JsonConvert.DeserializeObject<List<ResultPopularLocationDto>>(jsonData);
                    return View(popularLocations);
            }
         return View();
     }
}