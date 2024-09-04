namespace Soru8;

class Program
{
    static void Main(string[] args)
    {
       
    {
        
        Console.Write("Bir sayı giriniz: ");
        if (!int.TryParse(Console.ReadLine(), out int limit) || limit < 0)
        {
            Console.WriteLine("Lütfen geçerli bir pozitif tam sayı giriniz.");
            return;
        }

       
        int a = 0;
        int b = 1;

        
        if (limit >= 0)
        {
            Console.WriteLine("Fibonacci Serisi:");

            
            Console.Write(a + " ");
            if (limit > 0)
            {
                Console.Write(b + " ");
            }

            
            while (true)
            {
                int c = a + b;
                if (c > limit)
                {
                    break;
                }

                Console.Write(c + " ");

                
                a = b;
                b = c;
            }

            Console.WriteLine();
        }
    }
}

    }

