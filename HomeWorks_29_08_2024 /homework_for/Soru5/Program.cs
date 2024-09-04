namespace Soru5;

class Program
{
    static void Main(string[] args)
    {
      
{
    static void Main()
    {
        
        Console.Write("Bir sayı giriniz: ");
        if (!int.TryParse(Console.ReadLine(), out int sayi) || sayi < 0)
        {
            Console.WriteLine("Lütfen geçerli bir pozitif tam sayı giriniz.");
            return;
        }

        
        string sayiStr = sayi.ToString();

       
        char[] sayiDizisi = sayiStr.ToCharArray();
        Array.Reverse(sayiDizisi);
        string tersSayiStr = new string(sayiDizisi);

        
        int tersSayi = int.Parse(tersSayiStr);

       
        Console.WriteLine("Sonuç: " + tersSayi);
    }
}

    
    }}
