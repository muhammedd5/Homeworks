namespace Soru6;

class Program
{
    static void Main(string[] args)
    {
       
    {
    
        Console.Write("Bir pozitif tam sayı giriniz: ");
        if (!int.TryParse(Console.ReadLine(), out int sayi) || sayi <= 0)
        {
            Console.WriteLine("Lütfen geçerli bir pozitif tam sayı giriniz.");
            return;
        }

       
        int bolenSayisi = 0;

       
        for (int i = 1; i <= sayi; i++)
        {
            if (sayi % i == 0)
            {
                bolenSayisi++;
            }
        }

        
        Console.WriteLine("Pozitif bölenlerin sayısı: " + bolenSayisi);
    }
}

    }

