using Microsoft.AspNetCore.Mvc;

namespace RealEstateUI.ViewComponents.AdminLayout;

public class _AdminLayoutFooterComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}