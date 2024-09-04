using System;

namespace Soru1
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Console.WriteLine("Ondalıklı sayı giriniz: ");
            string girilenMetin = Console.ReadLine();

            
            if (double.TryParse(girilenMetin, out double ondalıklıSayı))
            {
                
                int yuvarlanmışSayı = (int)Math.Round(ondalıklıSayı);

                Console.WriteLine($"Yuvarlanmış sayı: {yuvarlanmışSayı}");
            }
            else
            {
                Console.WriteLine("Geçerli bir sayı giriniz.");
            }
        }
    }
}
