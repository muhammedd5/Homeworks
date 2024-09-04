namespace Soru3;

class Program
{
    static void Main(string[] args)
    {
       
    {
       
        const decimal acilisUcreti = 30.0m; 
        const decimal kmBasiUcret = 20.0m;     // 

        
        Console.Write("Gidilen mesafeyi kilometre olarak giriniz: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal mesafe) || mesafe < 0)
        {
            Console.WriteLine("Lütfen geçerli bir pozitif kilometre değeri giriniz.");
            return;
        }

        
        decimal taksimetreTutari = acilisUcreti + (mesafe * kmBasiUcret + 20);

        Console.WriteLine("Taksimetre Tutarı: " + taksimetreTutari.ToString("100"));
    }
}

    }

