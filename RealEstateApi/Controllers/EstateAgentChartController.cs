using Microsoft.AspNetCore.Mvc;
using RealEstateApi.Repositories.EstateAgentRepositories.DashboardRepositories.ChartRepositories;

namespace RealEstateApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class EstateAgentChartController : Controller
{
       private readonly IChartRepository _chartRepository;
    
        public EstateAgentChartController(IChartRepository chartRepository)
        {
            _chartRepository = chartRepository;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetFiveCityChartData()
        {
            var result = await _chartRepository.GetFiveCityChartData();
            if (result == null || !result.Any())
            {
                return NotFound("No data found.");
            }
            return Ok(result);
           
        } 
}