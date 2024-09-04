namespace Soru10;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Bir sayı girin: ");
        if (int.TryParse(Console.ReadLine(), out int sayi))
        {
            if (AsalMi(sayi))
            {
                Console.WriteLine($"{sayi} bir asal sayıdır.");
            }
            else
            {
                Console.WriteLine($"{sayi} bir asal sayı değildir.");
            }
        }
        else
        {
            Console.WriteLine("Lütfen geçerli bir sayı girin.");
        }
    }

    static bool AsalMi(int sayi)
    {
        if (sayi <= 1)
        {
            return false;
        }
        if (sayi == 2 || sayi == 3)
        {
            return true;
        }
        if (sayi % 2 == 0 || sayi % 3 == 0)
        {
            return false;
        }
        
        int i = 5;
        while (i * i <= sayi)
        {
            if (sayi % i == 0 || sayi % (i + 2) == 0)
            {
                return false;
            }
            i += 6;
        }
        
        return true;
    }
}
  
    
