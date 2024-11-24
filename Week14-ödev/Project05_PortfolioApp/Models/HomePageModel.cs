using System;

namespace Project05_PortfolioApp.Models;

public class HomePageModel
{
    public AppSetting? AppSetting { get; set; }
    public IEnumerable<Social>? Socials { get; set; }
    public IEnumerable<Skill>? Skills { get; set; }
    public IEnumerable<Service>? Services { get; set; }
    public IEnumerable<Category>? Categories { get; set; }
    public IEnumerable<Project>? Projects { get; set; }
    public Contact? Contact { get; set; }
    public string? ActivePage { get; set; }
}
