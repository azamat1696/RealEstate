using Microsoft.AspNetCore.Mvc;
using RealEstateApi.Dto;
using RealEstateApi.Repositories.CategoryRepository;

namespace RealEstateApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : Controller
{
    private readonly ICategoryRepository _categoryRepository;
    public CategoriesController(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    [HttpGet]
    public async Task<IActionResult> CategoryList()
    {
        var categories = await _categoryRepository.GetAllCategoryAsync();
        return Ok(categories);
    }
    [HttpPost]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDto createCategoryDto)
    {
        _categoryRepository.CreateCategoryAsync(createCategoryDto);
        return  Ok("Category Created");
    }
    [HttpDelete("{categoryId}")]
    public async Task<IActionResult> DeleteCategory(int categoryId)
    {
         _categoryRepository.DeleteCategoryAsync(categoryId);
        return Ok("Category Deleted");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryDto updateCategoryDto)
    {
        await _categoryRepository.UpdateCategoryAsync(updateCategoryDto);
        return Ok("Category Updated");
    }
    [HttpGet("{categoryId}")]
    public async Task<IActionResult> GetByIdCategory(int categoryId)
    {
        var category = await _categoryRepository.GetByIdCategoryAsync(categoryId);
        return Ok(category);
    }
}