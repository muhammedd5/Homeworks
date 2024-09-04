using System;

namespace Soru2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Birinci sayıyı giriniz: ");
            string birinciSayiMetin = Console.ReadLine();

            
            Console.WriteLine("İkinci sayıyı giriniz: ");
            string ikinciSayiMetin = Console.ReadLine();

            if (double.TryParse(birinciSayiMetin, out double birinciSayi) && 
                double.TryParse(ikinciSayiMetin, out double ikinciSayi))
            {
                if (birinciSayi > ikinciSayi)
                {
                    Console.WriteLine($"Büyük olan sayı: {birinciSayi}");
                }
                else if (ikinciSayi > birinciSayi)
                {
                    Console.WriteLine($"Büyük olan sayı: {ikinciSayi}");
                }
                else
                {
                    Console.WriteLine("Her iki sayı eşittir.");
                }
            }
            else
            {
                Console.WriteLine("Geçerli bir sayı giriniz.");
            }
        }
    }
}
