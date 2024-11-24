using System;
using System.ComponentModel.DataAnnotations;

namespace Project05_PortfolioApp.Models;

public class ContactModel
{
    public AppSetting? AppSetting { get; set; }

    [Display(Name = "Ad Soyad")]
    [Required(ErrorMessage = "Ad Soyad alanı boş bırakılamaz!")]
    public string? Name { get; set; }

    [Display(Name = "Email")]
    [Required(ErrorMessage = "Email alanı boş bırakılamaz!")]
    [EmailAddress(ErrorMessage = "Lütfen geçerli bir email adresi girinizi")]
    // [DataType(DataType.EmailAddress, ErrorMessage = "Lütfen geçerli bir email adresi giriniz!")]
    public string? Email { get; set; }

    [Display(Name = "Konu")]
    [Required(ErrorMessage = "Konu alanı boş bırakılamaz")]
    public string? Subject { get; set; }

    [Display(Name = "Mesajınız")]
    [Required(ErrorMessage = "Mesaj alanı boş bırakılamaz!")]
    public string? Message { get; set; }
}
