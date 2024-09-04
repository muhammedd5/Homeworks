namespace Soru2;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("1-12 arasında bir sayı girin: ");
        int sayi;
       
        while (!int.TryParse(Console.ReadLine(), out sayi) || sayi < 1 || sayi > 12)
        {
            Console.Write("Geçersiz giriş. Lütfen 1 ile 12 arasında bir sayı girin: ");
        }

        string[] aylar = {
            "Aralık",
            "Ocak",      
            "Şubat",  
            "Mart",       
            "Nisan",   
            "Mayıs",   
            "Haziran",       
            "Temmuz",
            "Ağustos",
            "Eylül",
            "Ekim",
            "Kasım"
        };

        Console.WriteLine($"Girdiğiniz sayıya göre ay: {aylar[sayi ]}");
    }
}




