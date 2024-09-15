using Microsoft.AspNetCore.Mvc;

namespace RealEstateUI.Controllers;

public class AdminController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}