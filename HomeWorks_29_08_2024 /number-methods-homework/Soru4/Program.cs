using System;

namespace KarekokuHesaplama
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Bir sayı giriniz: ");
            string girilenMetin = Console.ReadLine();

          
            if (double.TryParse(girilenMetin, out double sayi))
            {
            
                if (sayi < 0)
                {
                    Console.WriteLine("Negatif sayılar için karekök hesaplanamaz.");
                }
                else
                {
                    double karekök = Math.Sqrt(sayi);

                   
                    Console.WriteLine($"Sayının karekökü: {karekök}");
                }
            }
            else
            {
            
                Console.WriteLine("Geçerli bir sayı giriniz.");
            }
        }
    }
}

