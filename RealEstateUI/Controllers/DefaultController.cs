using Microsoft.AspNetCore.Mvc;

namespace RealEstateUI.Controllers;

public class DefaultController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}