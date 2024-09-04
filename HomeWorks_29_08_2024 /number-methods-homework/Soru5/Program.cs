namespace Soru5;

class Program
{
    static void Main(string[] args)
    {

        {
            
            Console.WriteLine("Üssü alınacak sayıyı giriniz: ");
            string tabanMetin = Console.ReadLine();

            Console.WriteLine("Üs olacak sayıyı giriniz: ");
            string üsMetin = Console.ReadLine();

        
            if (double.TryParse(tabanMetin, out double taban) &&
                double.TryParse(üsMetin, out double üs))
            {
                
                double sonuc = Math.Pow(taban, üs);

                
                Console.WriteLine($"{taban} üssü {üs}: {sonuc}");
            }
            else
            {
                
                Console.WriteLine("Geçerli sayılar giriniz.");
            }
        }
    }
}

    
