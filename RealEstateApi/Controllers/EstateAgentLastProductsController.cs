using Microsoft.AspNetCore.Mvc;
using RealEstateApi.Repositories.EstateAgentRepositories.DashboardRepositories.LastProductRepositories;

namespace RealEstateApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EstateAgentLastProductsController : Controller
{
    private readonly ILastFiveProducts _lastFiveProducts;

    public EstateAgentLastProductsController(ILastFiveProducts lastFiveProducts)
    {
        _lastFiveProducts = lastFiveProducts;
    }

    [HttpGet("GetLastFiveProducts/{employeeId}")]
    public async Task<IActionResult> GetLastFiveProducts(int employeeId)
    {
        var result = await _lastFiveProducts.GetLastFiveProductsAsync(employeeId);
        if (result == null || !result.Any())
        {
            return NotFound("No products found for the given employee.");
        }
        return Ok(result);
    }
}