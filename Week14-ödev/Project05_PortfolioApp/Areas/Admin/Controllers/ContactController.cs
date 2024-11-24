using Microsoft.AspNetCore.Mvc;
using Project05_PortfolioApp.Data;
using Project05_PortfolioApp.Models;

namespace Project05_PortfolioApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly IRepository<Contact> _contactRepository;

        public ContactController(IRepository<Contact> contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<ActionResult> Index()
        {
             ViewBag.Route = RouteData.Values["controller"];
            return View();
        }

        public async Task<ActionResult> Read(int id)
        {
            var contact = await _contactRepository.GetAsync(id);
            return View(contact);
        }

    }
}
