using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project05_PortfolioApp.Models;

public class Contact
{
    public int Id { get; set; }
    [Display(Name = "Ad Soyad")]
    [Required(ErrorMessage = "Ad Soyad alanı boş bırakılamaz!")]
    public string? Name { get; set; }

    [Display(Name = "Email")]
    [Required(ErrorMessage = "Email alanı boş bırakılamaz!")]
    // [EmailAddress(ErrorMessage = "Lütfen geçerli bir email adresi girinizi")]
    // [DataType(DataType.EmailAddress, ErrorMessage = "Lütfen geçerli bir email adresi giriniz!")]
    public string? Email { get; set; }

    [Display(Name = "Konu")]
    [Required(ErrorMessage = "Konu alanı boş bırakılamaz")]
    public string? Subject { get; set; }

    [Display(Name = "Mesajınız")]
    [Required(ErrorMessage = "Mesaj alanı boş bırakılamaz!")]
    public string? Message { get; set; }
    public bool IsRead { get; set; }
    public DateTime SendingTime { get; set; }
    public int? ContactId { get; set; }
}

// INSERT INTO Contacts(Name,Email,Subject,Message) VALUES('Engin','engin@gmail.com','Proje','Bitti mi?')