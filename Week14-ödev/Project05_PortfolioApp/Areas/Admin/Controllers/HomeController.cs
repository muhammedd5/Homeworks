using Microsoft.AspNetCore.Mvc;
using Project05_PortfolioApp.Data;
using Project05_PortfolioApp.Models;

namespace Project05_PortfolioApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IRepository<Contact> _contactRepository;

        public HomeController(IRepository<Contact> contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<ActionResult> Index()
        {
            var messages = await _contactRepository.GetAllAsync();
            return View(messages);
        }
    }
}
