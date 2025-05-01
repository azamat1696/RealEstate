using Microsoft.AspNetCore.Mvc;

namespace RealEstateUI.ViewComponents.Dashboard;

public class _DashboardStatisticsComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _clientFactory;
    public _DashboardStatisticsComponentPartial(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }
    
    public async Task<IViewComponentResult> InvokeAsync()
    {
        #region İstatistikler--Toplam ilan sayısı
        var client = _clientFactory.CreateClient();
        var response = await client.GetAsync("http://localhost:5059/api/Statistics/PropertyCount");
        var jsonData = await response.Content.ReadAsStringAsync();
        ViewBag.PropertyCount = jsonData;
        #endregion
        
        #region İstatistikler-başarılı çalışan çalışan sayısı
        var client2 = _clientFactory.CreateClient();
        var response2 = await client2.GetAsync("http://localhost:5059/api/Statistics/EmployeeWithMostProperties");
        var jsonData2 = await response2.Content.ReadAsStringAsync();
        ViewBag.EmployeeWithMostProperties = jsonData2;
        #endregion
        
        #region İstatistikler-İlandaki şehir sayıları
        var client3 = _clientFactory.CreateClient();
        var response3 = await client3.GetAsync("http://localhost:5059/api/Statistics/DifferentCityCount");
        var jsonData3 = await response3.Content.ReadAsStringAsync();
        ViewBag.DifferentCityCount = jsonData3;
        #endregion
        
        #region İstatistikler-Ortalama kira fiyatı
        var client4 = _clientFactory.CreateClient();
        var response4 = await client4.GetAsync("http://localhost:5059/api/Statistics/AveragePropertyByRentPrice");
        var jsonData4 = await response4.Content.ReadAsStringAsync();
        ViewBag.AveragePropertyByRentPrice = jsonData4;
        #endregion
        return View();
    }
}