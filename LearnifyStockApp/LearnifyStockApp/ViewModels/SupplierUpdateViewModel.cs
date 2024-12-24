using System.ComponentModel.DataAnnotations;

namespace LearnifyStockApp.ViewModels;

public class SupplierUpdateViewModel
{
    
public int Id { get; set; }

    [Display(Name = "Firma Adı")]
    [Required(ErrorMessage = "Firma adı boş bırakılamaz!")]
    public string? Name { get; set; }
    
    [Display(Name = "İletişim")]
    [Required(ErrorMessage = "İletişim boş bırakılamaz!")]
    public string? ContactName { get; set; }
    
    [Display(Name = "Email")]
    [Required(ErrorMessage = "Email boş bırakılamaz!")]
    public string? Email { get; set; }
    
    [Display(Name = "Telefon")]
    [Required(ErrorMessage = "Telefon boş bırakılamaz!")]
    public string? PhoneNumber { get; set; }
    [Display(Name = "Adres")]
    [Required(ErrorMessage = "Adres boş bırakılamaz")]
    public string? Address { get; set; }

    [Display(Name = "Şehir")]
    [Required(ErrorMessage = "Şehir boş bırakılamaz")]
    public string? City { get; set; }

    [Display(Name = "Ülke")]
    [Required(ErrorMessage = "Ülke boş bırakılamaz")]
    public string? Country { get; set; }

    public DateTime? UpdatedAt { get; set; }
}