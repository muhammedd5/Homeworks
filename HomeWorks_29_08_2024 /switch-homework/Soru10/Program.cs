using System;

namespace Soru10
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("1 ile 5 arasında bir sayı girin (1-5): ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int sayi) && sayi >= 1 && sayi <= 5)
            {
                string islem = islemBelirle(sayi);
                Console.WriteLine($"Girdiğiniz sayı için matematiksel işlem karşılığı: {islem}");
            }
            else
            {
                Console.WriteLine("Geçerli bir sayı girilmedi. Lütfen 1 ile 5 arasında bir sayı girin.");
            }
        }

        static string islemBelirle(int sayi)
        {
            switch (sayi)
            {
                case 1:
                    return "+";
                case 2:
                    return "-";
                case 3:
                    return "*";
                case 4:
                    return "/";
                case 5:
                    return "%";
                default:
                    return "Geçersiz sayı"; 
            }
        }
    }
}
