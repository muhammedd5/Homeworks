namespace Soru4;

class Program
{
    static void Main(string[] args)
    {
       Console.WriteLine("Bir cümle girin: ");
        string cumle = Console.ReadLine();

        string temizlenmisCumle = cumle.Trim();
        Console.WriteLine("Temizlenmiş cümle: " + temizlenmisCumle);
        
    }
}
