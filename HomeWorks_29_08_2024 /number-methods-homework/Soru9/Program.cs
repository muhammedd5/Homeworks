namespace Soru9;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Bir sayı giriniz");
        string birinciSayiMetin = Console.ReadLine();


        Console.WriteLine("Bir sayı giriniz");
        string ikinciSayiMetin = Console.ReadLine();

        if (double.TryParse(birinciSayiMetin. out birinciSayi) && double TryParse(ikinciSayiMetin, out double ikinciSayİ))
  
       {double kucukSayi = (birinciSayi < ikinciSayi) ? birinciSayi : ikinciSayi;
       }

       else
       {
        Console.WriteLine("Geçerli sayılar giriniz");
       }


    }
}
