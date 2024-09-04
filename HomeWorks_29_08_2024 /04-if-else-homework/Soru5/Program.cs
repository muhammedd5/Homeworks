namespace Soru5;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Birinci kenarı girin: ");
        double a = double.Parse(Console.ReadLine());
        
        Console.Write("İkinci kenarı girin: ");
        double b = double.Parse(Console.ReadLine());
        
        Console.Write("Üçüncü kenarı girin: ");
        double c = double.Parse(Console.ReadLine());

        if (IsTriangle(a, b,c))
        {
             Console.WriteLine("Girilen kenar uzunlukları bir üçgen oluşturur.");
        }

        else
        {
             Console.WriteLine("Girilen kenar uzunlukları bir üçgen oluşturmaz.");
        }
    }

         static bool IsTriangle(double a, double b, double c)
    {
        return (a + b > c) && (a + c > b) && (b + c > a);
    }

}


