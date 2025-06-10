using Dapper;
using Microsoft.AspNetCore.Mvc;
using RealEstateApi.Dto.LoginDtos;
using RealEstateApi.Models.DapperContext;
using RealEstateApi.Tools;

namespace RealEstateApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginController : Controller
{
    private readonly Context _context;
    public LoginController(Context context)
    {
        _context = context;
    }
    
    [HttpPost]
    public async Task<IActionResult> SignIn(CreateLoginDto createLoginDto)
    {
         string query = "SELECT * FROM app_user WHERE username = @Username AND password = @Password";
         var parameters = new DynamicParameters();
         parameters.Add("@Username", createLoginDto.Username);
         parameters.Add("@Password", createLoginDto.Password);

         using (var connection = _context.CreateConnection())
         {
             var user = await connection.QueryFirstOrDefaultAsync<ResultLoginDto>(query, parameters);
             if (user != null)
             {
                 GetCheckAppUserViewModel model = new GetCheckAppUserViewModel();
                 model.Username = user.Username;
                 model.Id = user.Id;
                 model.Role = user.User_Role.ToString();
                 model.IsExist = true;
                 var token = JwtTokenGenerator.GenerateToken(model);
                 return Ok(token);
             }
             return NotFound("User not found or invalid credentials");
         }
    }
}