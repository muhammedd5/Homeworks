using System.Data;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project05_PortfolioApp.Areas.Admin.Models;
using Project05_PortfolioApp.Models;

namespace Project05_PortfolioApp.Areas.Admin.Controllers;

 [Area("Admin")]
public class SocialController : Controller
{

    private readonly IDbConnection _dbConnection;

    public SocialController(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }


      public async Task<ActionResult> Index()
        {
            var query = @"
                SELECT
                    s.Id,
                    s.Name,
                    s.URL,
                    s.IsActive,
                    s.Icon
                FROM Socials s
            ";
            var socials = await _dbConnection.QueryAsync<Social>(query);
            return View(socials);
        }




        private List<SelectListItem> GetIconList()
        {
            List<SelectListItem> iconList = [
                new SelectListItem{ Text="bi-pinterest" , Value="bi-pinterest"},
                new SelectListItem{ Text="bi-facebook"},
                new SelectListItem{ Text="bi-reddit"},
                new SelectListItem{ Text="bi-tiktok"},
                new SelectListItem{ Text="bi-snapchat"},
                new SelectListItem{ Text="bi-youtube"},
              
             ];
            return iconList;
        }
        
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            AddSocialViewModel model = new()
            {
                IconList = GetIconList()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Create(AddSocialViewModel addSocialViewModel)
        {
            if (ModelState.IsValid)
            {
                var query = @"
                    INSERT INTO Socials(Name,Icon,URL,IsActive)
                    VALUES (@Name,@Icon,@URL,@IsActive)
                ";
                await _dbConnection.ExecuteAsync(query, addSocialViewModel);
                return RedirectToAction("Index");
            }
            addSocialViewModel.IconList = GetIconList();
            return View(addSocialViewModel);
        }

 




        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var query = @"
                SELECT s.Id, s.Name, s.Icon, s.URL, s.IsActive FROM Socials s WHERE Id=@Id
            ";
            var editedSocial = await _dbConnection.QueryFirstOrDefaultAsync<Social>(query, new { Id = id });
            if (editedSocial != null)
            {
                EditSocialViewModel model = new()
                {
                    Id = editedSocial.Id,
                    Name = editedSocial.Name,
                    URL = editedSocial.URL,
                    Icon = editedSocial.Icon,
                    IsActive = editedSocial.IsActive,
                    IconList = GetIconList()
                };
                return View(model);
            }
            return RedirectToAction("Index");
        }

     

        [HttpPost]
        public async Task<ActionResult> Edit(EditSocialViewModel editSocialViewModel)
        {
            if (ModelState.IsValid)
            {
              var query = @"
                UPDATE Socials 
                SET Name=@Name, Icon=@Icon, URL=@URL, IsActive=@IsActive
                WHERE Id=@Id
                ";
                await _dbConnection.ExecuteAsync(query, editSocialViewModel);
                return RedirectToAction("Index");
            }
            editSocialViewModel.IconList = GetIconList();
            return View(editSocialViewModel);
        }


               

        public async Task<ActionResult> Delete(int id)
        {
            var query = @"DELETE FROM Socials WHERE Id=@Id";
            await _dbConnection.ExecuteAsync(query, new { Id = id });
            return RedirectToAction("Index");
        }


           [HttpGet]



        // public async Task<ActionResult> UpdateIsActive(int id)
        // {
        //     var query = @"SELECT * FROM Socials s WHERE Id=@Id";
        //     var editedSocial = await _dbConnection.QueryFirstOrDefaultAsync<Social>(query, new { Id = id });
        //     if (editedSocial != null)
        //     {
        //         query = @"
        //             UPDATE Socials 
        //             SET IsActive=@IsActive
        //             WHERE Id=@Id
        //         ";
        //         var result = await _dbConnection.ExecuteAsync(query, new { IsActive = !editedSocial.IsActive, Id = id });
                
        //         return Json(new { success = true });
        //     }
        //     return RedirectToAction("Index");
        // }


        [HttpGet]
public async Task<ActionResult> UpdateIsActive(int id)
{
    var query = @"SELECT * FROM Socials c WHERE Id=@Id";
    var editedSocial = await _dbConnection.QueryFirstOrDefaultAsync<Social>(query, new { Id = id });
    if (editedSocial != null)
    {
        query = @"
            UPDATE Socials 
            SET IsActive=@IsActive
            WHERE Id=@Id
        ";
        var result = await _dbConnection.ExecuteAsync(query, new { IsActive = !editedSocial.IsActive, Id = id });
        return Json(new { success = true, newState = !editedSocial.IsActive });
    }
    return Json(new { success = false });
}

    }


