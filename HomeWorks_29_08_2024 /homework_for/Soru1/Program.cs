namespace Soru1;

class Program
{
    static void Main(string[] args)
    {
    
    {
        Console.Write("Bir sayı giriniz: ");
        int sayi = int.Parse(Console.ReadLine());

        int toplam = 0;
        int sayac = 0;

        for (int i = 12; i <= sayi; i += 12)
        {
            toplam += i;
            sayac++;
        }

        double ortalama;
        if (sayac > 0)
        {
            ortalama = (double)toplam / sayac;
            Console.WriteLine("Ortalama: " + ortalama);
        }
        else
        {
            Console.WriteLine("Belirtilen aralıkta 12'nin katı olan sayı bulunmuyor.");
        }
    }
}

    }
