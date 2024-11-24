using System;
using System.Data;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Project05_PortfolioApp.Data;
using Project05_PortfolioApp.Models;

namespace Project05_PortfolioApp.Areas.Admin.Controllers;

[Area("Admin")]
public class MessageController : Controller
{
    private readonly IDbConnection _dbConnection;

    public MessageController(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<ActionResult> Index(bool? id = null)
    {
        string query;
        bool? isRead = id;
        if (isRead == null)
        {
            query = @"SELECT * FROM Contacts";
        }
        else
        {
            query = @"SELECT * FROM Contacts WHERE IsRead=@IsRead";
        }
        var messages = await _dbConnection.QueryAsync<Contact>(query, new { IsRead = isRead });
        ViewBag.IsRead = isRead;
        return View(messages);
    }
}
