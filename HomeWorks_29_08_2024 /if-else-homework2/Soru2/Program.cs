namespace Soru2;

class Program
{
    static void Main(string[] args)
    {
       
    {
       
        Console.Write("Birinci kenar uzunluğunu giriniz: ");
        if (!double.TryParse(Console.ReadLine(), out double a) || a <= 0)
        {
            Console.WriteLine("Lütfen geçerli bir pozitif sayı giriniz.");
            return;
        }

        Console.Write("İkinci kenar uzunluğunu giriniz: ");
        if (!double.TryParse(Console.ReadLine(), out double b) || b <= 0)
        {
            Console.WriteLine("Lütfen geçerli bir pozitif sayı giriniz.");
            return;
        }

        Console.Write("Üçüncü kenar uzunluğunu giriniz: ");
        if (!double.TryParse(Console.ReadLine(), out double c) || c <= 0)
        {
            Console.WriteLine("Lütfen geçerli bir pozitif sayı giriniz.");
            return;
        }

    
        if (IsValidTriangle(a, b, c))
        {
            double s = (a + b + c) / 2;
            double alan = Math.Sqrt(s * (s - a) * (s - b) * (s - c));

            
            Console.WriteLine("Üçgenin Alanı: " + alan);
        }
        else
        {
            Console.WriteLine("Girdiğiniz kenar uzunlukları geçerli bir üçgen oluşturmaz.");
        }
    }

   
    static bool IsValidTriangle(double a, double b, double c)
    {
        return a + b > c && a + c > b && b + c > a;
    }
}

    }
