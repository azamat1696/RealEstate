using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstateUI.Dto.ProductDtos;
using RealEstateUI.Dto.ServiceDtos;
using RealEstateUI.Dto.WhoWeAreDtos;

namespace RealEstateUI.ViewComponents.HomePage;

public class _DefaultWoWeAreComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;
    public _DefaultWoWeAreComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var client2 = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("http://localhost:5059/api/WhoWeAreDetail");
        var servicesResponse = await client2.GetAsync("http://localhost:5059/api/Services");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var whoWeAreDetails = JsonConvert.DeserializeObject<List<ResultWhoWeAreDto>>(jsonData);
            ViewBag.Title = whoWeAreDetails.Select(x => x.title).FirstOrDefault();
            ViewBag.SubTitle = whoWeAreDetails.Select(x => x.subTitle).FirstOrDefault();
            ViewBag.Description1 = whoWeAreDetails.Select(x => x.description1).FirstOrDefault();
            ViewBag.Description2 = whoWeAreDetails.Select(x => x.description2).FirstOrDefault();
        }
        if (servicesResponse.IsSuccessStatusCode)
        {
             var jsonData = await servicesResponse.Content.ReadAsStringAsync();
             var services = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData);
             return View(services);
        }
        return View();
    }
}