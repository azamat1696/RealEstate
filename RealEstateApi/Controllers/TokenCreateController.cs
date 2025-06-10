using Microsoft.AspNetCore.Mvc;
using RealEstateApi.Tools;

namespace RealEstateApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TokenCreateController : Controller
{
    [HttpPost]
    public IActionResult CreateToken(GetCheckAppUserViewModel model)
    {
        if (model == null || !model.IsExist)
        {
            return BadRequest("Invalid user data.");
        }

        var token = JwtTokenGenerator.GenerateToken(model);
        return Ok(token);
    }
    
}