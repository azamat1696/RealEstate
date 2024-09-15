using Microsoft.AspNetCore.Mvc;

namespace RealEstateUI.ViewComponents.AdminLayout;

public class _AdminLayoutHeadComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}