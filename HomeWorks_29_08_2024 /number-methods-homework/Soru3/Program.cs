using System;

namespace Soru3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bir sayı giriniz: ");
            string girilenMetin = Console.ReadLine();

          
            if (double.TryParse(girilenMetin, out double sayi))
            {
            
                double mutlakDeger = Math.Abs(sayi);

                Console.WriteLine($"Sayının mutlak değeri: {mutlakDeger}");
            }
            else
            {
    
                Console.WriteLine("Geçerli bir sayı giriniz.");
            }
        }
    }
}
