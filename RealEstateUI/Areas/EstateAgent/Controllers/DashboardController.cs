using Microsoft.AspNetCore.Mvc;

namespace RealEstateUI.Areas.EstateAgent.Controllers;

[Area("EstateAgent")]
public class DashboardController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}