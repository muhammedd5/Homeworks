using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Project05_PortfolioApp.Data;
using Project05_PortfolioApp.Models;

namespace Project05_PortfolioApp.Controllers;

public class HomeController : Controller
{
    private readonly IRepository<AppSetting> _appSettingsRepository;
    private readonly IRepository<Social> _socialRepository;
    private readonly IRepository<Skill> _skillRepository;
    private readonly IRepository<Service> _serviceRepository;
    private readonly IRepository<Category> _categoryRepository;
    private readonly IRepository<Project> _projectRepository;
    private readonly IRepository<Contact> _contactRepository;
    public HomeController(IRepository<AppSetting> appSettingsRepository, IRepository<Social> socialRepository, IRepository<Skill> skillRepository, IRepository<Service> serviceRepository, IRepository<Category> categoryRepository, IRepository<Project> projectRepository, IRepository<Contact> contactRepository)
    {
        _appSettingsRepository = appSettingsRepository;
        _socialRepository = socialRepository;
        _skillRepository = skillRepository;
        _serviceRepository = serviceRepository;
        _categoryRepository = categoryRepository;
        _projectRepository = projectRepository;
        _contactRepository = contactRepository;
    }
    public async Task<IActionResult> Index()
    {
        var appSettings = (await _appSettingsRepository.GetAllAsync()).First();
        var socials = await _socialRepository.GetAllAsync(true);
        var skills = await _skillRepository.GetAllAsync();
        var services = await _serviceRepository.GetAllAsync();

        HomePageModel model = new()
        {
            AppSetting = appSettings,
            Socials = socials,
            Skills = skills,
            Services = services,
            ActivePage = "Ana Sayfa"
        };
        return View(model);
    }

    public async Task<IActionResult> About()
    {
        var appSettings = (await _appSettingsRepository.GetAllAsync()).First();
        var socials = await _socialRepository.GetAllAsync(true);
        HomePageModel model = new()
        {
            AppSetting = appSettings,
            Socials = socials,
            ActivePage = "Hakkımda"
        };
        return View(model);
    }

    public async Task<IActionResult> Services()
    {
        var appSettings = (await _appSettingsRepository.GetAllAsync()).First();
        var socials = await _socialRepository.GetAllAsync(true);
        var services = await _serviceRepository.GetAllAsync(true);
        HomePageModel model = new()
        {
            AppSetting = appSettings,
            Socials = socials,
            Services = services,
            ActivePage = "Hizmetler"
        };
        return View(model);
    }

    public async Task<IActionResult> Portfolio()
    {
        var appSettings = (await _appSettingsRepository.GetAllAsync()).First();
        var socials = await _socialRepository.GetAllAsync(true);
        var categories = await _categoryRepository.GetAllAsync(true);
        var projects = await _projectRepository.GetAllAsync(true);
        HomePageModel model = new()
        {
            AppSetting = appSettings,
            Socials = socials,
            Categories = categories,
            Projects = projects,
            ActivePage = "Projeler"
        };
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Contact()
    {
        var appSettings = (await _appSettingsRepository.GetAllAsync()).First();
        var socials = await _socialRepository.GetAllAsync(true);
        HomePageModel model = new()
        {
            AppSetting = appSettings,
            Socials = socials,
            ActivePage = "İletişim"
        };
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Contact(Contact contact)
    {
        if (!ModelState.IsValid)
        {
            var appSettings = (await _appSettingsRepository.GetAllAsync()).First();
            var socials = await _socialRepository.GetAllAsync(true);
            HomePageModel model = new()
            {
                AppSetting = appSettings,
                Socials = socials,
                Contact = contact,
                ActivePage = "İletişim"
            };
            return View(model);
        }
        contact.SendingTime = DateTime.Now;
        contact.ContactId = null;
        var result = await _contactRepository.AddAsync(contact);

        return RedirectToAction("Index");

    }

}
