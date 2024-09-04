using Microsoft.AspNetCore.Mvc;

namespace RealEstateUI.ViewComponents.HomePage;

public class _DefaultServicesComponentPartial: ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}