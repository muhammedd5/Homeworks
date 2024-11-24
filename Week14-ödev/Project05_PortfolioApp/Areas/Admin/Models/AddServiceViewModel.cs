using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Project05_PortfolioApp.Areas.Admin.Models;

public class AddServiceViewModel
{
    [Display(Name = "Hizmet Adı")]
    [Required(ErrorMessage = "Hizmet adı boş bırakılamaz!")]
    [MinLength(5, ErrorMessage = "Hizmet adı en az 5 karakter uzunluğunda olmalıdır.")]
    [MaxLength(20, ErrorMessage = "Hizmet adı en fazla 20 karakter uzunluğunda olmalıdır.")]
    public string? Title { get; set; }

    [Display(Name = "İkon")]
    [Required(ErrorMessage = "İkon boş bırakılamaz!")]
    public string? Icon { get; set; }

    [Display(Name = "Hizmet Açıklaması")]
    [Required(ErrorMessage = "Hizmet açıklaması boş bırakılamaz!")]
    [MinLength(5, ErrorMessage = "Hizmet açıklaması en az 5 karakter uzunluğunda olmalıdır.")]
    [MaxLength(20, ErrorMessage = "Hizmet açıklaması en fazla 20 karakter uzunluğunda olmalıdır.")]
    public string? Description { get; set; }

    [Display(Name = "Aktif")]
    public bool IsActive { get; set; }

    public List<SelectListItem> IconList { get; set; } = [];
}
