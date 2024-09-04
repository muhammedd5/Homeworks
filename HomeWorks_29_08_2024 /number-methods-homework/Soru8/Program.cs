namespace Soru8;

class Program
{
    static void Main(string[] args)
    {
            Console.WriteLine("Bir sayı giriniz: ");
            string girilenMetin = Console.ReadLine();

            if (double.TryParse(girilenMetin, out double sayi))
            {
                
                if (sayi > 0)
                {
                    double logaritma = Math.Log(sayi);

                
                    Console.WriteLine($"Sayının doğal logaritması: {logaritma}");
                }
                else
                {
                    Console.WriteLine("Doğal logaritma hesaplanabilmesi için pozitif bir sayı giriniz.");
                }
            }
            else
            {
                Console.WriteLine("Geçerli bir sayı giriniz.");
            }
        }
    }
