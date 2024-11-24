using System.Data;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project05_PortfolioApp.Areas.Admin.Models;
using Project05_PortfolioApp.Models;

namespace Project05_PortfolioApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceController : Controller
    {
        private readonly IDbConnection _dbConnection;

        public ServiceController(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<ActionResult> Index()
        {
            var query = @"
                SELECT
                    s.Id,
                    s.Title,
                    s.IsActive
                FROM Services s
            ";
            var services = await _dbConnection.QueryAsync<Service>(query);
            return View(services);
        }


        private List<SelectListItem> GetIconList()
        {
            List<SelectListItem> iconList = [
                new SelectListItem{ Text="bi-arrow-down-square"},
                new SelectListItem{ Text="bi-arrow-right-circle-fill"},
                new SelectListItem{ Text="bi-asterisk"},
                new SelectListItem{ Text="bi-activity"},
                new SelectListItem{ Text="bi-bounding-box-circles"},
                new SelectListItem{ Text="bi-calendar4-week"},
                new SelectListItem{ Text="bi-broadcast"}
             ];
            return iconList;
        }
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            AddServiceViewModel model = new()
            {
                IconList = GetIconList()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Create(AddServiceViewModel addServiceViewModel)
        {
            if (ModelState.IsValid)
            {
                var query = @"
                    INSERT INTO Services(Title,Icon,Description,IsActive)
                    VALUES (@Title,@Icon,@Description,@IsActive)
                ";
                await _dbConnection.ExecuteAsync(query, addServiceViewModel);
                return RedirectToAction("Index");
            }
            addServiceViewModel.IconList = GetIconList();
            return View(addServiceViewModel);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var query = @"
                SELECT s.Id, s.Title, s.Icon, s.Description, s.IsActive FROM Services s WHERE Id=@Id
            ";
            var editedService = await _dbConnection.QueryFirstOrDefaultAsync<Service>(query, new { Id = id });
            if (editedService != null)
            {
                EditServiceViewModel model = new()
                {
                    Id = editedService.Id,
                    Title = editedService.Title,
                    Description = editedService.Description,
                    Icon = editedService.Icon,
                    IsActive = editedService.IsActive,
                    IconList = GetIconList()
                };
                return View(model);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> Edit(EditServiceViewModel editServiceViewModel)
        {
            if (ModelState.IsValid)
            {
                var query = @"
                    UPDATE Services 
                    SET Title=@Title, Description=@Description, Icon=@Icon,IsActive=@IsActive
                    WHERE Id=@Id
                ";
                await _dbConnection.ExecuteAsync(query, editServiceViewModel);
                return RedirectToAction("Index");
            }
            editServiceViewModel.IconList = GetIconList();
            return View(editServiceViewModel);
        }

        public async Task<ActionResult> Delete(int id)
        {
            var query = @"DELETE FROM Services WHERE Id=@Id";
            await _dbConnection.ExecuteAsync(query, new { Id = id });
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> UpdateIsActive(int id)
        {
            var query = @"SELECT * FROM Services c WHERE Id=@Id";
            var editedService = await _dbConnection.QueryFirstOrDefaultAsync<Service>(query, new { Id = id });
            if (editedService != null)
            {
                query = @"
                    UPDATE Services 
                    SET IsActive=@IsActive
                    WHERE Id=@Id
                ";
                var result = await _dbConnection.ExecuteAsync(query, new { IsActive = !editedService.IsActive, Id = id });
                return Json(result);
            }
            return RedirectToAction("Index");
        }
    }
}
