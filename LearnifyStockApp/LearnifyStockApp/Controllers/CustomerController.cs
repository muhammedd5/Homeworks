using AspNetCoreHero.ToastNotification.Abstractions;
using LearnifyStockApp.Models.Repositories;
using LearnifyStockApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LearnifyStockApp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly CustomerRepository _customerRepository;
        private readonly INotyfService _notyfService;

        public CustomerController(CustomerRepository customerRepository, INotyfService notyfService)
        {
            _customerRepository = customerRepository;
            _notyfService = notyfService;
        }

        public async Task<ActionResult> Index(bool id)
        {
            bool isDeleted = id;
            ViewBag.IsDeleted = isDeleted;
            var customers = await _customerRepository.GetAllAsync(isDeleted);
            return View(customers);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(CustomerCreateViewModel customerCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                await _customerRepository.CreateAsync(customerCreateViewModel);
                _notyfService.Success("Müşteri başarıyla oluşturuldu!");
                return RedirectToAction("Index");
            }
            return View(customerCreateViewModel);
        }

        public async Task<ActionResult> Update(int id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);

            //Burada yaptığımız Customer tipindeki veriyi, CustomerUpdateViewModel tipindeki bir nesneye dönüştürme operasyonunu çeşitli nuget paketleri ile daha kolay yapmayı öğreneceksiniz. AutoMapper, Mapster vb.
            var customerUpdateViewModel = new CustomerUpdateViewModel
            {
                Id = customer.Id,
                Name = customer.Name,
                ContactName = customer.ContactName,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                Address = customer.Address,
                City = customer.City,
                Country = customer.Country,
                UpdatedAt = customer.UpdatedAt.Year == 1 ? null : customer.UpdatedAt
            };
            return View(customerUpdateViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Update(CustomerUpdateViewModel customerUpdateViewModel)
        {
            if (ModelState.IsValid)
            {
                await _customerRepository.UpdateAsync(customerUpdateViewModel);
                _notyfService.Success("Müşteri başarıyla güncellendi!");
                return RedirectToAction("Index");
            }
            return View(customerUpdateViewModel);
        }

        public async Task<ActionResult> SoftDelete(int id)
        {
            var isDeleted = await _customerRepository.SoftDeleteAsync(id);
            var message = isDeleted ? "Müşteri başarıyla geri alındı!" : "Müşteri çöp kutusuna gönderildi!";
            _notyfService.Success(message);
            return RedirectToAction("Index", new { id = isDeleted });
        }

        public async Task<ActionResult> HardDelete(int id)
        {
            var isDeleted = await _customerRepository.HardDeleteAsync(id);
            _notyfService.Success("Müşteri kalıcı olarak silindi!");
            return RedirectToAction("Index", new { id = isDeleted });
        }


        public async Task<ActionResult> SoftDeleteHome(int id)
        {
            var isDeleted = await _customerRepository.SoftDeleteAsync(id);
            var message = isDeleted ? "Müşteri başarıyla geri alındı!" : "Müşteri çöp kutusuna gönderildi!";
            _notyfService.Success(message);
            return Redirect("~/");
        }
    }
}
