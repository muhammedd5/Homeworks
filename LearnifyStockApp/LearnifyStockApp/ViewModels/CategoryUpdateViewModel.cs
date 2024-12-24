using System;
using System.ComponentModel.DataAnnotations;

namespace LearnifyStockApp.ViewModels;

public class CategoryUpdateViewModel
{
    public int Id { get; set; }

    [Display(Name = "Kategori")]
    [Required(ErrorMessage = "Kategori adı boş bırakılamaz!")]
    public string? Name { get; set; }

    [Display(Name = "Açıklama")]
    [Required(ErrorMessage = "Kategori açıklaması boş bırakılamaz!")]
    public string? Description { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
