using Microsoft.AspNetCore.Mvc;

namespace RealEstateUI.ViewComponents.HomePage;

public class _DefaultWoWeAreComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}