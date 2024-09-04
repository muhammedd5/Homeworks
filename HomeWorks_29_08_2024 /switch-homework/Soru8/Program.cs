using System;

namespace Soru8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("0 ile 6 arasında bir sayı girin (0-6): ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int sayi) && sayi >= 0 && sayi <= 6)
            {
                string sekil = SekilBelirle(sayi);
                Console.WriteLine($"Girdiğiniz sayı için şekil: {sekil}");
            }
            else
            {
                Console.WriteLine("Geçerli bir sayı girilmedi. Lütfen 0 ile 6 arasında bir sayı girin.");
            }
        }

        static string SekilBelirle(int sayi)
        {
            switch (sayi)
            {
                case 0:
                    return "Nokta";
                case 1:
                    return "Çizgi";
                case 2:
                    return "Açı";
                case 3:
                    return "Üçgen";
                case 4:
                    return "Kare";
                case 5:
                    return "Beşgen";
                case 6:
                    return "Altıgen";
                default:
                    return "Geçersiz sayı"; 
            }
        }
    }
}
