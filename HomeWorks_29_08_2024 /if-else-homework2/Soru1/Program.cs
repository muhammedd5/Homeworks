namespace Soru1;

class Program
{
    static void Main(string[] args)
    {
    {
        
        Console.Write("Bir para değeri giriniz (TL cinsinden): ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal para) || para < 0)
        {
            Console.WriteLine("Lütfen geçerli bir pozitif para değeri giriniz.");
            return;
        }

        
        decimal kdvOrani;
        if (para <= 1000)
        {
            kdvOrani = 0.20m; 
        }
        else
        {
            kdvOrani = 0.08m; 
        }

        
        decimal kdvTutari = para * kdvOrani;

        
        decimal kdvliFiyat = para + kdvTutari;

        
        Console.WriteLine("KDV Tutarı: " + kdvTutari.ToString("C2"));
        Console.WriteLine("KDV'li Fiyat: " + kdvliFiyat.ToString("C2"));
    }
}

    }
