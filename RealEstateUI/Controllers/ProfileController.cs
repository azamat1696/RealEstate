using Microsoft.AspNetCore.Mvc;

namespace RealEstateUI.Controllers;

public class ProfileController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}