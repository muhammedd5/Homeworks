using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Project05_PortfolioApp.Areas.Admin.Models;

public class AddProjectViewModel
{
    [Required(ErrorMessage = "Proje adı boş bırakılmamalıdır.")]
    [Display(Name = "Proje")]
    public string? Name { get; set; }
    public string? ImageUrl { get; set; }

    [Required(ErrorMessage = "Açıklama boş bırakılmamalıdır.")]
    [MinLength(5, ErrorMessage = "Açıklama en az 5 karakter uzunluğunda olmalıdır.")]
    [Display(Name = "Açıklama")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "Github Url boş bırakılmamalıdır.")]
    [Url(ErrorMessage = "Geçerli bir URL girilmelidir.")]
    [Display(Name = "Github Linki")]
    public string? GithubUrl { get; set; }

    [Display(Name = "Proje Linki")]
    public string? ProjectUrl { get; set; }

    [Required(ErrorMessage = "Proje Yıl bilgisi boş bırakılmamalıdır.")]
    [Display(Name = "Proje Yılı")]
    public int ProjectYear { get; set; }

    [Display(Name = "Aktif")]
    public bool IsActive { get; set; }
    public int CategoryId { get; set; }

    [Display(Name = "Kategori")]
    public List<SelectListItem>? CategoryList { get; set; }
}
