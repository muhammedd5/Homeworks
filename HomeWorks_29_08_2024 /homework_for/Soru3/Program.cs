namespace Soru3;

class Program
{
    static void Main(string[] args)
    {
        

    {
       
        Console.Write("Bir sayı giriniz: ");
        string input = Console.ReadLine();

       
        if (!input.All(char.IsDigit))
        {
            Console.WriteLine("Lütfen geçerli bir sayı giriniz.");
            return;
        }

    
        char[] rakamlar = input.ToCharArray();

       
        Array.Sort(rakamlar);


        Console.WriteLine("Sonuç: " + string.Join(",", rakamlar));
    }
}

    }

