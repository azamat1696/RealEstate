using Microsoft.AspNetCore.Mvc;
using RealEstateApi.Repositories.StatisticsRepositories;

namespace RealEstateApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class StatisticsController : Controller
{
    private readonly IStatisticsRepository _statisticsRepository;
    public StatisticsController(IStatisticsRepository statisticsRepository)
    {
        _statisticsRepository = statisticsRepository;
    }
    [HttpGet("ActiveCategoryCount")]
    public IActionResult ActiveCategoryCount()
    {
        return Ok(_statisticsRepository.ActiveCategoryCount());
    }
    [HttpGet("CategoryCount")]
    public IActionResult CategoryCount()
    {
        return Ok(_statisticsRepository.CategoryCount());
    }
    [HttpGet("InactiveCategoryCount")]
    public IActionResult InactiveCategoryCount()
    {
        return Ok(_statisticsRepository.InactiveCategoryCount());
    }
    [HttpGet("PropertyCount")]
    public IActionResult PropertyCount()
    {
        return Ok(_statisticsRepository.PropertyCount());
    }
    [HttpGet("ApartmentCount")]
    public IActionResult ApartmentCount()
    {
        return Ok(_statisticsRepository.ApartmentCount());
    }
    [HttpGet("EmployeeWithMostProperties")]
    public IActionResult EmployeeWithMostProperties()
    {
        return Ok(_statisticsRepository.EmployeeWithMostProperties());
    }
    [HttpGet("CategoryWithMostProperties")]
    public IActionResult CategoryWithMostProperties()
    {
        return Ok(_statisticsRepository.CategoryWithMostProperties());
    }
    [HttpGet("AveragePropertyByRentPrice")]
    public IActionResult AveragePropertyByRentPrice()
    {
        return Ok(_statisticsRepository.AveragePropertyByRentPrice());
    }
    [HttpGet("AveragePropertyBySalePrice")]
    public IActionResult AveragePropertyBySalePrice()
    {
        return Ok(_statisticsRepository.AveragePropertyBySalePrice());
    }
    [HttpGet("AverageRoomCount")]
    public IActionResult AverageRoomCount()
    {
        return Ok(_statisticsRepository.AverageRoomCount());
    }
    [HttpGet("CityNameByMaxProductCount")]
    public IActionResult CityNameByMaxProductCount()
    {
        return Ok(_statisticsRepository.CityNameByMaxProductCount());
    }
    [HttpGet("DifferentCityCount")]
    public IActionResult DifferentCityCount()
    {
        return Ok(_statisticsRepository.DifferentCityCount());
    }
    [HttpGet("LastPropertyPrice")]
    public IActionResult LastPropertyPrice()
    {
        return Ok(_statisticsRepository.LastPropertyPrice());
    }
    [HttpGet("NewestBuildingYear")]
    public IActionResult NewestBuildingYear()
    {
        return Ok(_statisticsRepository.NewestBuildingYear());
    }
    [HttpGet("OldestBuildingYear")]
    public IActionResult OldestBuildingYear()
    {
        return Ok(_statisticsRepository.OldestBuildingYear());
    }
    [HttpGet("ActiveEmployeeCount")]
    public IActionResult ActiveEmployeeCount()
    {
        return Ok(_statisticsRepository.ActiveEmployeeCount());
    }
    
}