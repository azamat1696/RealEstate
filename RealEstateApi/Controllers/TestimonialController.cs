using Microsoft.AspNetCore.Mvc;
using RealEstateApi.Dto.TestimonialDtos;
using RealEstateApi.Repositories.TestimonialRepository;

namespace RealEstateApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestimonialController : Controller
{
    private readonly ITestimonialRepository _testimonialRepository;
    
    public TestimonialController(ITestimonialRepository testimonialRepository)
    {
        _testimonialRepository = testimonialRepository;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllTestimonialAsync()
    {
        var result = await _testimonialRepository.GetAllTestimonialAsync();
        return Ok(result);
    }
    [HttpPost]
    public async Task<IActionResult> CreateTestimonialAsync(CreateTestimonialDto createTestimonialDto)
    {
         _testimonialRepository.CreateTestimonialAsync(createTestimonialDto);
        return Ok("Testimonial created successfully");
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTestimonialAsync(int id)
    {
        _testimonialRepository.DeleteTestimonialAsync(id);
        return Ok("Testimonial deleted successfully");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateTestimonialAsync(UpdateTestimonialDto updateTestimonialDto)
    {
        await _testimonialRepository.UpdateTestimonialAsync(updateTestimonialDto);
        return Ok("Testimonial updated successfully");
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdTestimonialAsync(int id)
    {
        var result = await _testimonialRepository.GetByIdTestimonialAsync(id);
        return Ok(result);
    }
  
}