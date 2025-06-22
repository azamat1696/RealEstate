using Microsoft.AspNetCore.Mvc;
using RealEstateUI.Services;

namespace RealEstateUI.ViewComponents.EstateAgent;

public class _EstateAgentStatisticsComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly ILoginService _loginService;
    public _EstateAgentStatisticsComponentPartial(IHttpClientFactory clientFactory, ILoginService loginService)
    {
        _clientFactory = clientFactory;
        _loginService = loginService;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var employeeId = _loginService.GetUserId;
        #region İstatistikler--Toplam ilan sayısı
        var client = _clientFactory.CreateClient();
        var response = await client.GetAsync("http://localhost:5059/api/EstateAgentDashboardStatistic/AllProductCount/"+employeeId);
        var jsonData = await response.Content.ReadAsStringAsync();
        ViewBag.PropertyCount = jsonData;
        #endregion
        
        #region İstatistikler-başarılı çalışan çalışan sayısı
        var client2 = _clientFactory.CreateClient();
        var response2 = await client2.GetAsync("http://localhost:5059/api/EstateAgentDashboardStatistic/ActiveProductCount/"+employeeId);
        var jsonData2 = await response2.Content.ReadAsStringAsync();
        ViewBag.ActiveProductCount = jsonData2;
        #endregion
        
        #region İstatistikler-İlandaki şehir sayıları
        var client3 = _clientFactory.CreateClient();
        var response3 = await client3.GetAsync("http://localhost:5059/api/EstateAgentDashboardStatistic/InactiveProductCount/"+employeeId);
        var jsonData3 = await response3.Content.ReadAsStringAsync();
        ViewBag.InactiveProductCount = jsonData3;
        #endregion
        
        #region İstatistikler-Ortalama kira fiyatı
        var client4 = _clientFactory.CreateClient();
        var response4 = await client4.GetAsync("http://localhost:5059/api/EstateAgentDashboardStatistic/ProductCountByEmployeeId/"+employeeId);
        var jsonData4 = await response4.Content.ReadAsStringAsync();
        ViewBag.ProductCountByEmployeeId = jsonData4;
        #endregion
        return View();
    }
}