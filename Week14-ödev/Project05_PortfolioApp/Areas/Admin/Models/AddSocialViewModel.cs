using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Project05_PortfolioApp.Areas.Admin.Models;

public class AddSocialViewModel
{
    [Display(Name = "Sosyal Medya")]
    [Required(ErrorMessage = "Sosyal Medya adı boş bırakılamaz!")]
    [MinLength(5, ErrorMessage = "Sosyal Medya adı en az 5 karakter uzunluğunda olmalıdır.")]
    [MaxLength(20, ErrorMessage = "Sosyal Medya adı en fazla 20 karakter uzunluğunda olmalıdır.")]
    public string? Name { get; set; }

    [Display(Name = "İkon")]
    [Required(ErrorMessage = "İkon boş bırakılamaz!")]
    public string? Icon { get; set; }

    [Display(Name = "URL Adresi")]
    [Required(ErrorMessage = "URL Adresi boş bırakılamaz!")]
    [MinLength(5, ErrorMessage = "URL Adresi en az 5 karakter uzunluğunda olmalıdır.")]
    [MaxLength(2000, ErrorMessage = "URL Adresi en fazla 20 karakter uzunluğunda olmalıdır.")]
public string? URL { get; set; }

    [Display(Name = "Aktif")]
    public bool IsActive { get; set; }

    public List<SelectListItem> IconList { get; set; } = [];
}
