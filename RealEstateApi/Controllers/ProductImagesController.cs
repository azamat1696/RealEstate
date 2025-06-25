using Microsoft.AspNetCore.Mvc;
using RealEstateApi.Repositories.ProductImageRepositories;

namespace RealEstateApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductImagesController : Controller
{
    private readonly IProductImageRepository _productImageRepository;
    public ProductImagesController(IProductImageRepository productImageRepository)
    {
        _productImageRepository = productImageRepository;
    }
    [HttpGet]
    public async Task<IActionResult> GetProductImageByProductId(int productId)
    {
        var productImage = await _productImageRepository.GetProductImageByProductId(productId);
        return Ok(productImage);
    }
  
}