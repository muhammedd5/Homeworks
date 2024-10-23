using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
               ViewBag.Categories = new List<string> { "Teknoloji", "Seyahat", "Ekonomi" };

            return View();
        }
    }
}
