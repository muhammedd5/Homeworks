namespace Soru10;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Lütfen bir sayı giriniz: (HHmm)");
        string saat12 = Console.ReadLine();

        DateTime saat24 = DateTime.Parse(saat12);
        Console.WriteLine(saat24);
    }
}
