using Microsoft.AspNetCore.Mvc;
using RealEstateApi.Dto.BottomGridDtos;
using RealEstateApi.Repositories.BottomGridRepository;

namespace RealEstateApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BottomGridController : Controller
{
    private readonly IBottomGridRepository _bottomGridRepository;
    public BottomGridController(IBottomGridRepository bottomGridRepository)
    {
        _bottomGridRepository = bottomGridRepository;
    }
    [HttpGet]
    public async Task<IActionResult> GetBottomGridList()
    {
        var bottomGrids = await _bottomGridRepository.GetAllBottomGridAsync();   
        return Ok(bottomGrids);
    }
    [HttpPost]
    public async Task<IActionResult> CreateBottomGrid([FromBody] CreateBottomGridDto createBottomGridDto)
    {
        _bottomGridRepository.CreateBottomGridAsync(createBottomGridDto);
        return Ok("BottomGrid Created");
    }
    [HttpDelete("{bottomGridId}")]
    public async Task<IActionResult> DeleteBottomGrid(int bottomGridId)
    {
        _bottomGridRepository.DeleteBottomGridAsync(bottomGridId);
        return Ok("BottomGrid Deleted");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateBottomGrid([FromBody] UpdateBottomGridDto updateBottomGridDto)
    {
        await _bottomGridRepository.UpdateBottomGridAsync(updateBottomGridDto);
        return Ok("BottomGrid Updated");
    }
    [HttpGet("{bottomGridId}")]
    public async Task<IActionResult> GetByIdBottomGrid(int bottomGridId)
    {
        var bottomGrid = await _bottomGridRepository.GetByIdBottomGridAsync(bottomGridId);
        return Ok(bottomGrid);
    }
    
}