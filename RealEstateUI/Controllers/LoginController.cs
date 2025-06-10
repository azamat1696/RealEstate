using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstateUI.Dto.LoginDtos;
using RealEstateUI.Models;
using JsonSerializer = System.Text.Json.JsonSerializer;
using JsonSerializerOptions = System.Text.Json.JsonSerializerOptions;

namespace RealEstateUI.Controllers;

public class LoginController : Controller
{  
    private readonly IHttpClientFactory _httpClientFactory;
    public LoginController(IHttpClientFactory clientFactory)
    {
        _httpClientFactory = clientFactory;
    }
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Index(CreateLoginDto createLoginDto)
    {
        var client = _httpClientFactory.CreateClient();
        var json = JsonConvert.SerializeObject(createLoginDto);
        var data = new StringContent(json, Encoding.UTF8, "application/json");
        
        var response = await client.PostAsync("http://localhost:5059/api/Login", data);
        if (response.IsSuccessStatusCode)
        {
            var token = await response.Content.ReadAsStringAsync();
            // Store the token in session or cookies as needed
            var tokenModel = JsonSerializer.Deserialize<JwtResponseModel>(token, new JsonSerializerOptions
            {
               PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            if (tokenModel != null)
            {
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = tokenHandler.ReadJwtToken(tokenModel.Token);
                var claims = jwtToken.Claims.ToList();
                if (tokenModel.Token != null)
                {
                    claims.Add(new Claim("realestatetoken", tokenModel.Token));
                    var identity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
                    var authProps = new AuthenticationProperties
                    {
                        IsPersistent = true,
                        ExpiresUtc = tokenModel.ExpireDate // Set the expiration time as needed
                    };
                    await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(identity), authProps);
                    return RedirectToAction("Index", "MyAdverts");
                }
            }
            return RedirectToAction("Index", "Home");
        }
        
        ModelState.AddModelError("", "Invalid login attempt.");
        return View();
    }
}