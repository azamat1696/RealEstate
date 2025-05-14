using Microsoft.AspNetCore.Mvc;

namespace RealEstateUI.Controllers;

public class TestController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}