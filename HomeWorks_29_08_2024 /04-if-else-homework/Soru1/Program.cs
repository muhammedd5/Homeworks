using System;

namespace Soru1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Bir sayı giriniz: ");
            string input = Console.ReadLine();

            if (double.TryParse(input, out double sayi))
            {
                if (sayi > 0)
                {
                    Console.WriteLine("Sayı pozitiftir.");
                }
                else if (sayi < 0)
                {
                    Console.WriteLine("Sayı negatiftir.");
                }
                else
                {
                    Console.WriteLine("Sayı sıfırdır.");
                }
            }
            else
            {
                Console.WriteLine("Geçersiz bir sayı girdiniz.");
            }
        }
    }
}
