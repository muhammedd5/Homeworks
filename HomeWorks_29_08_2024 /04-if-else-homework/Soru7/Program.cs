namespace Soru7;

class Program
{
    static void Main(string[] args)
    {
          Console.WriteLine("Birinci sayıyı giriniz: ");
            if (!double.TryParse(Console.ReadLine(), out double num1))
            {
                Console.WriteLine("Geçersiz bir sayı girdiniz.");
                return;
            }

            Console.WriteLine("İkinci sayıyı giriniz: ");
            if (!double.TryParse(Console.ReadLine(), out double num2))
            {
                Console.WriteLine("Geçersiz bir sayı girdiniz.");
                return;
            }

            Console.WriteLine("Üçüncü sayıyı giriniz: ");
            if (!double.TryParse(Console.ReadLine(), out double num3))
            {
                Console.WriteLine("Geçersiz bir sayı girdiniz.");
                return;
            }
            double max = FindMax(num1, num2, num3);

            
            Console.WriteLine($"Girilen sayılardan en büyüğü: {max}");
        }

        
        static double FindMax(double a, double b, double c)
        {
            double max = a;

            if (b > max)
                max = b;

            if (c > max)
                max = c;

            return max;
        }
    }

