using Microsoft.AspNetCore.Mvc;

namespace RealEstateUI.ViewComponents.Layout;

public class _HeaderViewComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}