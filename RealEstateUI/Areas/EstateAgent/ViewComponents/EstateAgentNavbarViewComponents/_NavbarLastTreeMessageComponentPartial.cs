using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstateUI.Dto.MessageDtos;
using RealEstateUI.Services;

namespace RealEstateUI.Areas.EstateAgent.ViewComponents.EstateAgentNavbarViewComponents;

public class _NavbarLastTreeMessageComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILoginService _loginService;
    public _NavbarLastTreeMessageComponentPartial(IHttpClientFactory httpClientFactory, ILoginService loginService)
    {
        _httpClientFactory = httpClientFactory;
        _loginService = loginService;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var employeeId = _loginService.GetUserId;
        var response = await client.GetAsync("http://localhost:5059/api/Messages?receiverId="+employeeId);
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var messages = JsonConvert.DeserializeObject<List<ResultInBoxMessageDto>>(jsonData);
            return View(messages);
        }
        //return empty model
        return View(new List<ResultInBoxMessageDto>());
    }
    
}