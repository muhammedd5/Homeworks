namespace Soru7;

class Program
{
    static void Main(string[] args)

    {
        
        Console.Write("Bir pozitif tam sayı giriniz: ");
        if (!int.TryParse(Console.ReadLine(), out int sayi) || sayi <= 0)
        {
            Console.WriteLine("Lütfen geçerli bir pozitif tam sayı giriniz.");
            return;
        }

       
        int toplam = 0;

       
        for (int i = 1; i < sayi; i++)
        {
            if (sayi % i == 0)
            {
                toplam += i;
            }
        }

    
        if (toplam == sayi)
        {
            Console.WriteLine(sayi + " mükemmel bir sayıdır.");
        }
        else
        {
            Console.WriteLine(sayi + " mükemmel bir sayı değildir.");
        }
    }
}

    