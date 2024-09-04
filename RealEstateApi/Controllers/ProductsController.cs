using Microsoft.AspNetCore.Mvc;
using RealEstateApi.Repositories.ProductRepository;

namespace RealEstateApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductsController : Controller
{
    private readonly IProductRepository _productRepository;
    public ProductsController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    [HttpGet]
    public async Task<IActionResult> ProductList()
    {
        var products = await _productRepository.GetAllProductsAsync();
        return Ok(products);
    }
    [HttpGet("ProductsWithCategory")]
    public async Task<IActionResult> ProductListWithCategory()
    {
        var products = await _productRepository.GetAllProductsWithCategoryAsync();
        return Ok(products);
    }
}