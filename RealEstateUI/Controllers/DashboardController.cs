using Microsoft.AspNetCore.Mvc;

namespace RealEstateUI.Controllers;

public class DashboardController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}