using Microsoft.AspNetCore.Mvc;
namespace RealEstateUI.Controllers;

public class StatisticsController : Controller
{
    private readonly IHttpClientFactory _clientFactory;
    public StatisticsController(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }
    // GET
    public async Task<IActionResult> Index()
    {
        #region İstatistikler1
        var client = _clientFactory.CreateClient();
        var response = await client.GetAsync("http://localhost:5059/api/Statistics/ActiveCategoryCount");
        var jsonData = await response.Content.ReadAsStringAsync();
        ViewBag.ActiveCategoryCount = jsonData;
        #endregion
        #region İstatistikler2
        var client2 = _clientFactory.CreateClient();
        var response2 = await client2.GetAsync("http://localhost:5059/api/Statistics/ActiveEmployeeCount");
        var jsonData2 = await response2.Content.ReadAsStringAsync();
        ViewBag.ActiveEmployeeCount = jsonData2;
        #endregion
        #region İstatistikler3
        var client3 = _clientFactory.CreateClient();
        var response3 = await client3.GetAsync("http://localhost:5059/api/Statistics/ApartmentCount");
        var jsonData3 = await response3.Content.ReadAsStringAsync();
        ViewBag.ApartmentCount = jsonData3;
        #endregion

        #region İstatistikler4
        var client4 = _clientFactory.CreateClient();
        var response4 = await client4.GetAsync("http://localhost:5059/api/Statistics/AveragePropertyByRentPrice");
        var jsonData4 = await response4.Content.ReadAsStringAsync();
        ViewBag.AveragePropertyByRentPrice = jsonData4;
        #endregion

        #region İstatistikler5
        var client5 = _clientFactory.CreateClient();
        var response5 = await client5.GetAsync("http://localhost:5059/api/Statistics/AverageRoomCount");
        var jsonData5 = await response5.Content.ReadAsStringAsync();
        ViewBag.AverageRoomCount = jsonData5;
        #endregion
        
        #region İstatistikler6
        var client6 = _clientFactory.CreateClient();
        var response6 = await client6.GetAsync("http://localhost:5059/api/Statistics/CityNameByMaxProductCount");
        var jsonData6 = await response6.Content.ReadAsStringAsync();
        ViewBag.CityNameByMaxProductCount = jsonData6;
        #endregion
        
        #region İstatistikler7
        var client7 = _clientFactory.CreateClient();
        var response7 = await client7.GetAsync("http://localhost:5059/api/Statistics/PropertyCount");
        var jsonData7 = await response7.Content.ReadAsStringAsync();
        ViewBag.PropertyCount = jsonData7;
        #endregion
        
        #region İstatistikler8
        var client8 = _clientFactory.CreateClient();
        var response8 = await client8.GetAsync("http://localhost:5059/api/Statistics/EmployeeWithMostProperties");
        var jsonData8 = await response8.Content.ReadAsStringAsync();
        ViewBag.EmployeeWithMostProperties = jsonData8;
        #endregion
        
        #region İstatistikler9
        var client9 = _clientFactory.CreateClient();
        var response9 = await client9.GetAsync("http://localhost:5059/api/Statistics/CategoryWithMostProperties");
        var jsonData9 = await response9.Content.ReadAsStringAsync();
        ViewBag.CategoryWithMostProperties = jsonData9;
        #endregion
        #region İstatistikler10
        var client10 = _clientFactory.CreateClient();
        var response10 = await client10.GetAsync("http://localhost:5059/api/Statistics/AveragePropertyBySalePrice");
        var jsonData10 = await response10.Content.ReadAsStringAsync();
        ViewBag.AveragePropertyBySalePrice = jsonData10;
        #endregion

        #region İstatistikler11
        var client11 = _clientFactory.CreateClient();
        var response11 = await client11.GetAsync("http://localhost:5059/api/Statistics/DifferentCityCount");
        var jsonData11 = await response11.Content.ReadAsStringAsync();
        ViewBag.DifferentCityCount = jsonData11;
        #endregion
        #region İstatistikler12
        var client12 = _clientFactory.CreateClient();
        var response12 = await client12.GetAsync("http://localhost:5059/api/Statistics/LastPropertyPrice");
        var jsonData12 = await response12.Content.ReadAsStringAsync();
        ViewBag.LastPropertyPrice = jsonData12;
        #endregion
        #region İstatistikler13
        var client13 = _clientFactory.CreateClient();
        var response13 = await client13.GetAsync("http://localhost:5059/api/Statistics/NewestBuildingYear");
        var jsonData13 = await response13.Content.ReadAsStringAsync();
        ViewBag.NewestBuildingYear = jsonData13;
        #endregion
        #region İstatistikler14
        var client14 = _clientFactory.CreateClient();
        var response14 = await client14.GetAsync("http://localhost:5059/api/Statistics/OldestBuildingYear");
        var jsonData14 = await response14.Content.ReadAsStringAsync();
        ViewBag.OldestBuildingYear = jsonData14;
        #endregion
        #region İstatistikler15
        var client15 = _clientFactory.CreateClient();
        var response15 = await client15.GetAsync("http://localhost:5059/api/Statistics/ActiveEmployeeCount");
        var jsonData15 = await response15.Content.ReadAsStringAsync();
        ViewBag.ActiveEmployeeCount = jsonData15;
        #endregion
        return View();
    }
}