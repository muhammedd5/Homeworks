namespace Soru10;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Bir ondalıklı sayı giriniz: ");
        string ondalikliSayiMetin = (Console.ReadLine);

        Console.WriteLine("Bir ondalıklı basamak giriniz: ");
        string ondalikliBasamakMetin = (Console.ReadLine);

        if (double.TryParse(ondalikliSayiMetin, out double ondalıklıSayı) && int.TryParse(basamakSayisiMetin, out int basamakSayisi))
{
        double yuvarlanmisSayi = Math.Round(ondalikliSayi, basamakSayisi);
        }

      {
        Console.WriteLine($"Yuvarlanmış sayı: {yuvarlanmisSayi}");
       }

       else
       {
          Console.WriteLine("Geçerli bir sayı ve ondalık basamak sayısı giriniz.");
       }


    }
}
