using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstateUI.Dto.ProductDtos;
using RealEstateUI.Services;

namespace RealEstateUI.ViewComponents.EstateAgent;

public class _EstateAgentLastFiveProductComponentPartial : ViewComponent
{
     private readonly IHttpClientFactory _httpClientFactory;
     private readonly ILoginService _loginService;

     public _EstateAgentLastFiveProductComponentPartial(IHttpClientFactory httpClientFactory, ILoginService loginService)
     {
          _httpClientFactory = httpClientFactory;
          _loginService = loginService;
     }

     public async Task<IViewComponentResult> InvokeAsync()
     {
          var userId = _loginService.GetUserId;
          var client = _httpClientFactory.CreateClient();
          var response = await client.GetAsync("http://localhost:5059/api/Products/GetLastFiveProducts/"+userId);
          if (response.IsSuccessStatusCode)
          {
               var jsonData = await response.Content.ReadAsStringAsync();
               var products = JsonConvert.DeserializeObject<List<ResultLastFiveProductWithCategoryDto>>(jsonData);
               return View(products);
          }
          return View();
     }
}