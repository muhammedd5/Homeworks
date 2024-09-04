namespace Soru4;

class Program
{
    static void Main(string[] args)
    {
    
    {
       
        Console.Write("Bir sayı giriniz: ");
        if (!int.TryParse(Console.ReadLine(), out int sayi) || sayi <= 0)
        {
            Console.WriteLine("Lütfen pozitif bir tam sayı giriniz.");
            return;
        }

       
        int toplam = 0;

        
        Console.WriteLine("Çarpanlar:");
        for (int i = 1; i <= sayi; i++)
        {
            if (sayi % i == 0)
            {
                Console.Write(i + " ");
                toplam += i;
            }
        }

        Console.WriteLine();
        Console.WriteLine("Çarpanların toplamı: " + toplam);
    }
}

    }

