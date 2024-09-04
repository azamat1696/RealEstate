using Microsoft.AspNetCore.Mvc;

namespace RealEstateUI.ViewComponents.Layout;

public class _HeadViewComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}