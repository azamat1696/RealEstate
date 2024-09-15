using Microsoft.AspNetCore.Mvc;

namespace RealEstateUI.ViewComponents.AdminLayout;

public class _AdminLayoutNavbarComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}