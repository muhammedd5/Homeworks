namespace Soru4;

class Program
{
    static void Main(string[] args)
    {
      
    {
       
        const double pi = Math.PI;

      
        Console.Write("Dairenin yarıçapını giriniz: ");
        if (!double.TryParse(Console.ReadLine(), out double yaricap) || yaricap <= 0)
        {
            Console.WriteLine("Lütfen geçerli bir pozitif sayı giriniz.");
            return;
        }

        
        double alan = pi * yaricap * yaricap;
        double cevre = 2 * pi * yaricap;

        
        Console.WriteLine("Dairenin Alanı: " + alan.ToString("F2"));
        Console.WriteLine("Dairenin Çevresi: " + cevre.ToString("F2"));
    }
}

    }

