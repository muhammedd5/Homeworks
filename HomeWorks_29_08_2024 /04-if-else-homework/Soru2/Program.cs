namespace Soru2;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Birinci sayıyı giriniz: ");
        string input1 = Console.ReadLine();
        Console.Write("İkinci sayıyı giriniz: ");
        string input2 = Console.ReadLine();
        Console.Write("Üçüncü sayıyı giriniz: ");
        string input3 = Console.ReadLine();
        
        if (double.TryParse(input1, out double sayi1) &&  double.TryParse(input2, out double sayi2) &&  double.TryParse(input3, out double sayi3))
        {
            double[] sayilar = {sayi1, sayi2, sayi3};

                Array.Sort(sayilar);
                Array.Reverse(sayilar);

                Console.WriteLine("Sayılar büyükten küçüğe sıralı:");
                foreach (double sayi in sayilar)
                {
                    Console.WriteLine(sayi);
                }
            }
            else
            {
                Console.WriteLine("Geçersiz giriş! Lütfen geçerli sayılar giriniz.");
            }
        }
    }

