using System;

namespace Soru9
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("1 ile5 arasında bir sayı girin (1-5): ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int sayi) && sayi >= 1 && sayi <= 5)
            {
                string sifat = sifatBelirle(sayi);
                Console.WriteLine($"Girdiğiniz sayı için şekil: {sifat}");
            }
            else
            {
                Console.WriteLine("Geçerli bir sayı girilmedi. Lütfen 1 ile 5 arasında bir sayı girin.");
            }
        }

        static string sifatBelirle(int sayi)
        {
            switch (sayi)
            {
                case 1:
                    return "Birinci";
                case 2:
                    return "İkinci";
                case 3:
                    return "Üçüncü";
                case 4:
                    return "Dördüncü";
                case 5:
                    return "Beşinci";
                default:
                    return "Geçersiz sayı"; 
            }
        }
    }
}
