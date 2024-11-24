using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Project05_PortfolioApp.Areas.Admin.Models;

public class AddSkillViewModel
{
    [Display(Name = "Beceri Adı")]
    [Required(ErrorMessage = "Beceri adı boş bırakılamaz!")]
    [MinLength(2, ErrorMessage = "Beceri adı en az 2 karakter uzunluğunda olmalıdır.")]
    [MaxLength(20, ErrorMessage = "Beceri adı en fazla 20 karakter uzunluğunda olmalıdır.")]
    public string? Name { get; set; }

    [Display(Name = "Derece")]
    [Required(ErrorMessage = "Derece boş bırakılamaz!")]
    [Range(0, 100, ErrorMessage = "Rate 0 ile 100 arasında olmalıdır.")]
    public byte Rate { get; set; }

    

    [Display(Name = "Aktif")]
    public bool IsActive { get; set; }

  
}



