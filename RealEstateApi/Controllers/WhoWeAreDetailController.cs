using Microsoft.AspNetCore.Mvc;
using RealEstateApi.Dto.WhoWeAreDetailDtos;
using RealEstateApi.Repositories.WhoWeAreDetailRepository;

namespace RealEstateApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WhoWeAreDetailController : Controller
{
     private readonly IWhoWeAreDetailRepository _detailRepository;
     public WhoWeAreDetailController(IWhoWeAreDetailRepository detailRepository)
     {
         _detailRepository = detailRepository;
     }
     [HttpGet]
     public async Task<IActionResult> WhoWeAreDetailList()
     {
         var details = await _detailRepository.GetAllWhoWeAreDetailAsync(); 
         return Ok(details);
    }
    [HttpPost]
    public async Task<IActionResult> CreateWhoWeAreDetail([FromBody] CreateWhoWeAreDetailDto createWhoWeAreDetailDto)
    {
        _detailRepository.CreateWhoWeAreDetailAsync(createWhoWeAreDetailDto);
        return Ok("WhoWeAreDetail Created");
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteWhoWeAreDetail(int id)
    {
        _detailRepository.DeleteWhoWeAreDetailAsync(id);
        return Ok("WhoWeAreDetail Deleted");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateWhoWeAreDetail([FromBody] UpdateWhoWeAreDetailDto updateWhoWeAreDetailDto)
    {
        await _detailRepository.UpdateWhoWeAreDetailAsync(updateWhoWeAreDetailDto);
        return Ok("Who we are detail updated");
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdWhoWeAreDetail(int id)
    {
        var value = await _detailRepository.GetByIdWhoWeAreDetailAsync(id);
        return Ok(value);
    }
}