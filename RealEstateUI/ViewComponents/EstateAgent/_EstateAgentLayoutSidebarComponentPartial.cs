using Microsoft.AspNetCore.Mvc;

namespace RealEstateUI.ViewComponents.EstateAgent;

public class _EstateAgentLayoutSidebarComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}