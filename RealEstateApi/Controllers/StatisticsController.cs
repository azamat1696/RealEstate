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
}