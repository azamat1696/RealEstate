using Microsoft.AspNetCore.Mvc;
using RealEstateApi.Repositories.EstateAgentRepositories.DashboardRepositories.StatisticRepositories;

namespace RealEstateApi.Controllers;
[Route("/api/[controller]")]
[ApiController]
public class EstateAgentDashboardStatisticController : Controller
{
    private readonly IStatisticRepository _statisticRepository;
    public EstateAgentDashboardStatisticController(IStatisticRepository statisticRepository)
    {
        _statisticRepository = statisticRepository;
    }
    [HttpGet("ProductCountByEmployeeId/{employeeId}")]
    public IActionResult ProductCountByEmployeeId(int employeeId)
    {
        var count = _statisticRepository.ProductCountByEmployeeId(employeeId);
        return Ok(count);
    }
    [HttpGet("ActiveProductCount/{employeeId}")]
    public IActionResult ActiveProductCount(int employeeId)
    {
        var count = _statisticRepository.ActiveProductCount(employeeId);
        return Ok(count);
    }
    [HttpGet("InactiveProductCount/{employeeId}")]
    public IActionResult InactiveProductCount(int employeeId)
    {
        var count = _statisticRepository.InactiveProductCount(employeeId);
        return Ok(count);
    }
    [HttpGet("AllProductCount/{employeeId}")]
    public IActionResult AllProductCount(int employeeId)
    {
        var count = _statisticRepository.AllProductCount(employeeId);
        return Ok(count);
    }
}