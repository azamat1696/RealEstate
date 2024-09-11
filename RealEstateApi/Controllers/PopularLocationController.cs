using Microsoft.AspNetCore.Mvc;
using RealEstateApi.Dto.PopularLocationDtos;
using RealEstateApi.Repositories.PopularLocationRepository;

namespace RealEstateApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PopularLocationController : Controller
{
    private  IPopularLocationRepository _popularLocationRepository;
    public PopularLocationController(IPopularLocationRepository popularLocationRepository)
    {
        _popularLocationRepository = popularLocationRepository;
    }
    [HttpGet]
    public async Task<IActionResult> GetPopularLocations()
    {
        var popularLocations = await _popularLocationRepository.GetAllPopularLocationAsync();
        return Ok(popularLocations);
    }
    [HttpPost]
    public async Task<IActionResult> CreatePopularLocation([FromBody] CreatePopularLocationDto createPopularLocationDto)
    { 
        _popularLocationRepository.CreatePopularLocationAsync(createPopularLocationDto);
        return Ok("Popular Location Created");
    }
    [HttpDelete("{popularLocationId}")]
    public async Task<IActionResult> DeletePopularLocation(int popularLocationId)
    {
        _popularLocationRepository.DeletePopularLocationAsync(popularLocationId);
        return Ok("Popular Location Deleted");
    }
    [HttpPut]
    public async Task<IActionResult> UpdatePopularLocation([FromBody] UpdatePopularLocationDto updatePopularLocationDto)
    {
        await _popularLocationRepository.UpdatePopularLocationAsync(updatePopularLocationDto);
        return Ok("Popular Location Updated");
    }
    [HttpGet("{popularLocationId}")]
    public async Task<IActionResult> GetByIdPopularLocation(int popularLocationId)
    {
        var popularLocation = await _popularLocationRepository.GetByIdPopularLocationAsync(popularLocationId);
        return Ok(popularLocation);
    }
}