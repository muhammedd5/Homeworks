namespace Soru7;

class Program
{
    static void Main(string[] args)
    {

        {
            Console.Write("1. Sayiyi giriniz: ");
            int sayi1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("2.Sayiyi giriniz: ");
            int sayi2 = Convert.ToInt32(Console.ReadLine());
 
            Console.WriteLine("\n1. Toplama\n2.Çıkarma\n3.Çarpma\n4.Bölme");
            Console.Write("\nİsleminizi seciniz: ");
            int islem = Convert.ToInt32(Console.ReadLine());
            switch (islem)
            {
                case 1:
                    Console.WriteLine("İslemin sonucu = " + (sayi1 + sayi2));
                    break;
                case 2:
                    Console.WriteLine("İslemin sonucu = " + (sayi1 - sayi2));
                    break;
                case 3:
                    Console.WriteLine("İslemin sonucu = " + (sayi1 * sayi2));
                    break;
                case 4:
                    Console.WriteLine("İslemin sonucu = " + (sayi1 / sayi2));
                    break;
                default:
                    Console.WriteLine("Yanlis secim yaptınız !!");
                    break;
            }
            Console.ReadLine();
        }
    }
}
    

