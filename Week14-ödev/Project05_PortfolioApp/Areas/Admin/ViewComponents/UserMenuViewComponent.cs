using System;
using Microsoft.AspNetCore.Mvc;

namespace Project05_PortfolioApp.Areas.Admin.ViewComponents;

public class UserMenuViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        return View();
    }
}
