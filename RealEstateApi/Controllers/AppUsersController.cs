using Microsoft.AspNetCore.Mvc;
using RealEstateApi.Repositories.AppUserRepositories;

namespace RealEstateApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AppUsersController : Controller
{
    private readonly IAppUserRepository _appUserRepository;

    public AppUsersController(IAppUserRepository appUserRepository)
    {
        _appUserRepository = appUserRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAppUsersByProductId(int productId)
    {
        var result = await _appUserRepository.GetAppUsersByProductIdAsync(productId);
        return Ok(result);
    }
}