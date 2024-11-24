using System.Data;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project05_PortfolioApp.Areas.Admin.Models;
using Project05_PortfolioApp.Models;


namespace Project05_PortfolioApp.Areas.Admin.Controllers;

[Area("Admin")]
public class SkillController : Controller
{
    private readonly IDbConnection _dbConnection;
    public SkillController(IDbConnection dbConnection)
    {
         _dbConnection = dbConnection;
    }

     public async Task<ActionResult> Index()
        {
            var query = @"
                SELECT
                    s.Id,
                    s.Name,
                    s.Rate,
                    s.IsActive
                FROM Skills s
            ";
            var Skills = await _dbConnection.QueryAsync<Skill>(query);
            return View(Skills);
        }


     [HttpGet]
        public async Task<ActionResult> Create()
        {
            AddSkillViewModel model = new()
            {
               
            };
            return View(model);
        }

    [HttpPost]
        public async Task<ActionResult> Create(AddSkillViewModel addSkillViewModel)
        {
            if (ModelState.IsValid)
            {
                var query = @"
                    INSERT INTO Skills(Name,Rate,IsActive)
                    VALUES (@Name,@Rate,@IsActive)
                ";
                await _dbConnection.ExecuteAsync(query, addSkillViewModel);
                return RedirectToAction("Index");
            }
            
            return View(addSkillViewModel);
        }


        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var query = @"
                SELECT s.Id, s.Name, s.Rate, s.IsActive FROM Skills s WHERE Id=@Id
            ";
            var editedskill = await _dbConnection.QueryFirstOrDefaultAsync<Skill>(query, new { Id = id });
            if (editedskill != null)
            {
                EditSkillViewModel model = new()
                {
                    Id = editedskill.Id,
                    Name = editedskill.Name,
                    Rate = editedskill.Rate,
                    IsActive = editedskill.IsActive,
                 
                };
                return View(model);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> Edit(EditSkillViewModel editSkillViewModel)
        {
            if (ModelState.IsValid)
            {
                var query = @"
                    UPDATE Skills 
                    SET Name=@Name, Rate=@Rate, IsActive=@IsActive
                    WHERE Id=@Id
                ";
                await _dbConnection.ExecuteAsync(query, editSkillViewModel);
                return RedirectToAction("Index");
            }
            
            return View(editSkillViewModel);
        }

    public async Task<ActionResult> Delete(int id)
        {
            var query = @"DELETE FROM Skills WHERE Id=@Id";
            await _dbConnection.ExecuteAsync(query, new { Id = id });
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> UpdateIsActive(int id)
        {
            var query = @"SELECT * FROM Skills c WHERE Id=@Id";
            var editedSkill = await _dbConnection.QueryFirstOrDefaultAsync<Skill>(query, new { Id = id });
            if (editedSkill != null)
            {
                query = @"
                    UPDATE Skills 
                    SET IsActive=@IsActive
                    WHERE Id=@Id
                ";
                var result = await _dbConnection.ExecuteAsync(query, new { IsActive = !editedSkill.IsActive, Id = id });
                return Json(result);
            }
            return RedirectToAction("Index");
        }
    }



