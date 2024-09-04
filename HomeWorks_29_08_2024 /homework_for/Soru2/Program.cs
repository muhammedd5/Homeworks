namespace Soru2;

class Program
{
    static void Main(string[] args)
    {
        
        Console.Write("Çarpım tablosunun üst limitini giriniz: ");
        int limit = int.Parse(Console.ReadLine());

        
        for (int i = 1; i <= limit; i++)
        {
        
            Console.WriteLine($"{i}'ler");
            Console.WriteLine(new string('-', 5));

            
            for (int j = 1; j <= 10; j++)
            {
                Console.WriteLine($"{i}x{j}={i * j}");
            }

           
            Console.WriteLine();
        }
    }
}

    