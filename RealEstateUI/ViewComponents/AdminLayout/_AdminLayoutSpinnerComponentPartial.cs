using Microsoft.AspNetCore.Mvc;

namespace RealEstateUI.ViewComponents.AdminLayout;

public class _AdminLayoutSpinnerComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}