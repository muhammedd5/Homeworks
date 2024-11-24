using System;
using Microsoft.AspNetCore.Mvc;

namespace Project05_PortfolioApp.Areas.Admin.ViewComponents;

public class SidebarMenuViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        ViewBag.Route = RouteData.Values["controller"];
        return View();
    }
}
