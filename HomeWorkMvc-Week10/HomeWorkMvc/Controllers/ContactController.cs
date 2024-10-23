using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
    }
}
