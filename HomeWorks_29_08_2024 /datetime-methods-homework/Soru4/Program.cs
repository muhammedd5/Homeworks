namespace Soru4;

class Program
{
    static void Main(string[] args)
    {
      DateTime baslamaTarihi = new DateTime (2024, 03, 21);
      DateTime bitisTarihi = new DateTime (2024,11, 15);
     TimeSpan kalangun = bitisTarihi - baslamaTarihi;

     double toplamGun = kalangun.TotalDays; 
     Console.WriteLine(kalangun.TotalDays);

     


    }
}
