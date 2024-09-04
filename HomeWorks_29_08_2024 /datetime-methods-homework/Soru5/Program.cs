namespace Soru5;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Tarihi (YYYY-MM-DD) formatında girin!");
        string tarihInput = Console.ReadLine();

        DateTime tarih; 
        bool tarihGeçerli = DateTime.TryParseExact(tarihInput, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out tarih);

        if (!tarihGeçerli)

        {
            Console.WriteLine("Geçersiz tarih formatı.");
            return;
        }

         int gunSayisi = tarih.DayOfYear;
         Console.WriteLine("Bu tarih yılın " + gunSayisi + ". günüdür.");

    }
}
