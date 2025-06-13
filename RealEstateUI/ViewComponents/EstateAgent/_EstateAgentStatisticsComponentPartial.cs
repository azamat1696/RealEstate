using Microsoft.AspNetCore.Mvc;

namespace RealEstateUI.ViewComponents.EstateAgent;

public class _EstateAgentStatisticsComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}