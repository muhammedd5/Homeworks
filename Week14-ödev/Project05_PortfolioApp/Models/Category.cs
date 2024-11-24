using System;

namespace Project05_PortfolioApp.Models;

public class Category
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
}

