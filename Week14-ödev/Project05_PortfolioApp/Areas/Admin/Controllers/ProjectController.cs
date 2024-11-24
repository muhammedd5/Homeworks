using System.Data;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project05_PortfolioApp.Areas.Admin.Models;
using Project05_PortfolioApp.Helpers;
using Project05_PortfolioApp.Models;

namespace Project05_PortfolioApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProjectController : Controller
    {
        private readonly IDbConnection _dbConnection;
        private readonly ImageHelper _imageHelper;

        public ProjectController(IDbConnection dbConnection, ImageHelper imageHelper)
        {
            _dbConnection = dbConnection;
            _imageHelper = imageHelper;
        }

        private async Task<List<SelectListItem>> GetCategoryList()
        {
            var query = "SELECT Id, Name FROM Categories WHERE IsActive=1";
            var categories = await _dbConnection.QueryAsync<Category>(query);
            List<SelectListItem> result = [];
            foreach (var category in categories)
            {
                result.Add(new SelectListItem
                {
                    Text = category.Name,
                    Value = category.Id.ToString()
                });
            }
            return result;
        }
        public async Task<ActionResult> Index()
        {
            //Sorgumu hazırlayıp, veritabanı bağlantısını kullanarak çalıştırıp sonucu elde edeceğim.
            var query = @"
                SELECT 
                    p.Id,
                    p.Name,
                    p.Description,
                    p.GithubUrl,
                    p.ImageUrl,
                    p.IsActive,
                    c.Name as CategoryName
                FROM Projects p JOIN Categories c on p.CategoryId=c.Id
            ";
            var projects = await _dbConnection.QueryAsync<Project>(query);
            return View(projects);
        }
        public async Task<ActionResult> Create()
        {
            AddProjectViewModel model = new()
            {
                IsActive = true,
                CategoryList = await GetCategoryList()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddProjectViewModel model, IFormFile image)
        {


            var imageModel = await _imageHelper.UploadImage(image, "projects");
            if (!imageModel.IsSuccess)
            {
                model.CategoryList = await GetCategoryList();
                ViewBag.ImageError = imageModel.ErrorMessage;
                return View(model);
            }
            model.ImageUrl = imageModel.ImageUrl;

            if (ModelState.IsValid)
            {
                var query = @"
                    INSERT INTO 
                        Projects(
                            Name,
                            Description,
                            CategoryId,
                            GithubUrl,
                            ProjectUrl,
                            ProjectYear,
                            IsActive,
                            ImageUrl)
                    VALUES (@Name,@Description,@CategoryId,@GithubUrl,@ProjectUrl,@ProjectYear,@IsActive,@ImageUrl);
                ";
                var result = await _dbConnection.ExecuteAsync(query, model);
                return RedirectToAction("Index");

            }

            model.CategoryList = await GetCategoryList();
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var query = @"
                SELECT *
                FROM Projects p
                WHERE p.Id=@Id
            ";
            var editedProject = await _dbConnection.QueryFirstOrDefaultAsync<Project>(query, new { Id = id });
            if (editedProject != null)
            {
                EditProjectViewModel model = new()
                {
                    Id = editedProject.Id,
                    Name = editedProject.Name,
                    CategoryId = editedProject.CategoryId,
                    Description = editedProject.Description,
                    GithubUrl = editedProject.GithubUrl,
                    ImageUrl = editedProject.ImageUrl,
                    IsActive = editedProject.IsActive,
                    ProjectUrl = editedProject.ProjectUrl,
                    ProjectYear = editedProject.ProjectYear,
                    CategoryList = await GetCategoryList()
                };
                return View(model);
            }
            return RedirectToAction("Index");

        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditProjectViewModel model)
        {

            if (ModelState.IsValid)
            {
                if (model.Image != null)//Eski resim kullanılmayıp, yeni resim seçilmişse
                {
                    var imageModel = await _imageHelper.UploadImage(model.Image, "projects");
                    if (!imageModel.IsSuccess)
                    {
                        model.CategoryList = await GetCategoryList();
                        ViewBag.ImageError = imageModel.ErrorMessage;
                        return View(model);
                    }
                    model.ImageUrl = imageModel.ImageUrl;
                }
                var query = @"
                    UPDATE Projects 
                    SET Name=@Name, Description=@Description, CategoryId=@CategoryId, ImageUrl=@ImageUrl, GithubUrl=@GithubUrl, IsActive=@IsActive, ProjectUrl=@ProjectUrl, ProjectYear=@ProjectYear
                    WHERE Id=@Id
                ";
                var result = await _dbConnection.ExecuteAsync(query, model);
                return RedirectToAction("Index");
            }
            model.CategoryList = await GetCategoryList();
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var query = $@"
                DELETE FROM Projects WHERE Id = @id";
            var result = await _dbConnection.ExecuteAsync(query, new { id });
            return RedirectToAction("Index");

        }

        public async Task<IActionResult> UpdateIsActive(int id)
        {
            var query = @"
                SELECT *
                FROM Projects p
                WHERE p.Id=@Id
            ";
            var editedProject = await _dbConnection.QueryFirstOrDefaultAsync<Project>(query, new { Id = id });


            if (editedProject != null)
            {
                editedProject.IsActive = !editedProject.IsActive;
                query = @"
                    UPDATE Projects 
                    SET Name=@Name, Description=@Description, CategoryId=@CategoryId, ImageUrl=@ImageUrl, GithubUrl=@GithubUrl, IsActive=@IsActive, ProjectUrl=@ProjectUrl, ProjectYear=@ProjectYear
                    WHERE Id=@Id
                ";
                var result = await _dbConnection.ExecuteAsync(query, editedProject);
                
                return Json(result);
            }

            return RedirectToAction("Index");
        }
    }
}
