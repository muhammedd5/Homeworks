using System;
using Microsoft.AspNetCore.Mvc;

namespace Project05_PortfolioApp.Areas.Admin.ViewComponents;

public class MessagesViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        //Burada veri tabanından ihtiyaç duyulan veriler çekilebilir.
        //Buradaki View metodu, default olarak Views/Shared/Components/Messages/Default.cshtml viewini render etmek üzere çalıştırır.
        return View();
    }
}
