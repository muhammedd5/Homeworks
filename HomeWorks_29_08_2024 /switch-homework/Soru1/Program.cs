namespace Soru1;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("1-7 arasında bir sayı girin: ");
        int sayi;
       
        while (!int.TryParse(Console.ReadLine(), out sayi) || sayi < 1 || sayi > 7)
        {
            Console.Write("Geçersiz giriş. Lütfen 1 ile 7 arasında bir sayı girin: ");
        }

        string[] gunler = {
            "Pazar",      
            "Pazartesi",  
            "Salı",       
            "Çarşamba",   
            "Perşembe",   
            "Cuma",       
            "Cumartesi"   
        };

        Console.WriteLine($"Girdiğiniz sayıya göre gün: {gunler[sayi]}");
    }
}

