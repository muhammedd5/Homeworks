using AspNetCoreHero.ToastNotification.Abstractions;
using LearnifyStockApp.Models.Repositories;
using LearnifyStockApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LearnifyStockApp.Controllers
{
    public class SupplierController : Controller
    {
    private readonly SupplierRepository _supplierRepository;

    private readonly INotyfService _notyfService;

     public SupplierController(SupplierRepository supplierRepository, INotyfService notyfService)
        {
            _supplierRepository = supplierRepository;
            _notyfService = notyfService;
        }

    public async Task<ActionResult> Index(bool id)
        {
            bool isDeleted = id;
            ViewBag.IsDeleted = isDeleted;
            var suppliers = await _supplierRepository.GetAllAsync(isDeleted);
            return View(suppliers);
        }

     public ActionResult Create()
        {
            return View();
        }

    [HttpPost]
        public async Task<ActionResult> Create(SupplierCreateViewModel supplierCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                await _supplierRepository.CreateAsync(supplierCreateViewModel);
                _notyfService.Success("Tedarikçi başarıyla oluşturuldu!");
                return RedirectToAction("Index");
            }
            return View(supplierCreateViewModel);
        }

      public async Task<ActionResult> Update(int id)
        {
            var supplier = await _supplierRepository.GetByIdAsync(id);

            //Burada yaptığımız Supplier tipindeki veriyi, SupplierUpdateViewModel tipindeki bir nesneye dönüştürme operasyonunu çeşitli nuget paketleri ile daha kolay yapmayı öğreneceksiniz. AutoMapper, Mapster vb.
            var supplierUpdateViewModel = new SupplierUpdateViewModel
            {
                Id = supplier.Id,
                Name = supplier.Name,
                ContactName = supplier.ContactName,
                Email = supplier.Email,
                PhoneNumber = supplier.PhoneNumber,
                Address = supplier.Address,
                City = supplier.City,
                Country = supplier.Country,
                UpdatedAt = supplier.UpdatedAt.Year == 1 ? null : supplier.UpdatedAt
            };
            return View(supplierUpdateViewModel);
        }

     [HttpPost]
        public async Task<ActionResult> Update(SupplierUpdateViewModel supplierUpdateViewModel)
        {
            if (ModelState.IsValid)
            {
                await _supplierRepository.UpdateAsync(supplierUpdateViewModel);
                _notyfService.Success("Tedarikçi başarıyla güncellendi!");
                return RedirectToAction("Index");
            }
            return View(supplierUpdateViewModel);
        }

           public async Task<ActionResult> SoftDelete(int id)
        {
            var isDeleted = await _supplierRepository.SoftDeleteAsync(id);
            var message = isDeleted ? "Tedarikçi başarıyla geri alındı!" : "Tedarikçi çöp kutusuna gönderildi!";
            _notyfService.Success(message);
            return RedirectToAction("Index", new { id = isDeleted });
        }

        public async Task<ActionResult> HardDelete(int id)
        {
            var isDeleted = await _supplierRepository.HardDeleteAsync(id);
            _notyfService.Success("Tedarikçi kalıcı olarak silindi!");
            return RedirectToAction("Index", new { id = isDeleted });
        }

    }
}
