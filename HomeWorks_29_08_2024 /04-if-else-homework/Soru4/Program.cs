namespace Soru4;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Bir yıl girin: ");
        int year = int.Parse(Console.ReadLine());

        if ((year % 4 == 0 && year % 100 != 0) || (year % 400 ==0))

        {
            Console.WriteLine($"{year} artık yıldır.");
        
        }
        else{
         Console.WriteLine($"{year} artık yıl değildir.");  
        }
    }
}
