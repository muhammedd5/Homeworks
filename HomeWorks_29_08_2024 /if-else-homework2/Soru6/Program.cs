namespace Soru6;

class Program
{
    static void Main(string[] args)
    {
    {
        
        const decimal armutFiyat = 45.50m;
        const decimal bamyaFiyat = 81.40m;
        const decimal domatesFiyat = 45.00m;
        const decimal muzFiyat = 65.00m;
        const decimal patlicanFiyat = 45.00m;

        
        Console.Write("Armut (kg): ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal armutKg) || armutKg < 0)
        {
            Console.WriteLine("Lütfen geçerli bir kilogram değeri giriniz.");
            return;
        }

        Console.Write("Bamya (kg): ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal bamyaKg) || bamyaKg < 0)
        {
            Console.WriteLine("Lütfen geçerli bir kilogram değeri giriniz.");
            return;
        }

        Console.Write("Domates (kg): ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal domatesKg) || domatesKg < 0)
        {
            Console.WriteLine("Lütfen geçerli bir kilogram değeri giriniz.");
            return;
        }

        Console.Write("Muz (kg): ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal muzKg) || muzKg < 0)
        {
            Console.WriteLine("Lütfen geçerli bir kilogram değeri giriniz.");
            return;
        }

        Console.Write("Patlıcan (kg): ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal patlicanKg) || patlicanKg < 0)
        {
            Console.WriteLine("Lütfen geçerli bir kilogram değeri giriniz.");
            return;
        }

        
        decimal toplamTutar = (armutKg * armutFiyat) +
                              (bamyaKg * bamyaFiyat) +
                              (domatesKg * domatesFiyat) +
                              (muzKg * muzFiyat) +
                              (patlicanKg * patlicanFiyat);

       
        Console.WriteLine("Toplam Tutar: " + toplamTutar.ToString("C2"));
    }
}

    }
