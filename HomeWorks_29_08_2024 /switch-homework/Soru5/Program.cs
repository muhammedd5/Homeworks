namespace Soru5;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("1-4 arasında bir sayı girin: ");
        int sayi;
       
        while (!int.TryParse(Console.ReadLine(), out sayi) || sayi < 1 || sayi > 4)
        {
            Console.Write("Geçersiz giriş. Lütfen 1 ile 4 arasında bir sayı girin: ");
        }

        string[] mevsim = {
          "İlkbahar",
          "Yaz",
          "Sonbahar",
          "Kış"
        };

        Console.WriteLine($"Girdiğiniz sayıya göre mevsim: {mevsim[sayi ]}");
    }
}