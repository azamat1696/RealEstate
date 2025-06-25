using Microsoft.AspNetCore.Mvc;
using RealEstateApi.Repositories.ProductRepository;

namespace RealEstateApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductDetailsController : Controller
{
    private readonly IProductRepository _productRepository;

    public ProductDetailsController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    
    [HttpGet("GetProductDetailsById")]
    public async Task<IActionResult> GetProductDetailsById(int id)
    {
        var productDetails = await _productRepository.GetProductDetailsById(id);
        return Ok(productDetails);
    }
    
}