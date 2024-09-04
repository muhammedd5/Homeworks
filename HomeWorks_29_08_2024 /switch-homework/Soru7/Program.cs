namespace Soru7;

class Program
{
    static void Main(string[] args)
    {
        static void Main(string[] args)
        {
            Console.Write("1 ile 5 arasında bir sayı girin (1-5): ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int sayi) && sayi >= 1 && sayi <= 5)
            {
                string paraBirimi = ParaBirimiBelirle(sayi);
                Console.WriteLine($"Girdiğiniz sayı için para birimi: {paraBirimi}");
            }
            else
            {
                Console.WriteLine("Geçerli bir sayı girilmedi. Lütfen 1 ile 5 arasında bir sayı girin.");
            }
        }

        static string ParaBirimiBelirle(int sayi)
        {
            switch (sayi)
            {
                case 1:
                    return "1 Kr";
                case 2:
                    return "5 Kr";
                case 3:
                    return "10 Kr";
                case 4:
                    return "25 Kr";
                case 5:
                    return "50 Kr";
                default:
                    return "Geçersiz sayı"; 
            }
        }
    }
}

    
