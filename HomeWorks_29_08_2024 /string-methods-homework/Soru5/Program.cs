using System;

namespace Soru5
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Ana metni girin: ");
            string anaMetin = Console.ReadLine();

            
            Console.WriteLine("Aranacak metni girin: ");
            string aranacakMetin = Console.ReadLine(); 

          
            int indeks = anaMetin.IndexOf(aranacakMetin);
            
            if (indeks != -1)
            {
                Console.WriteLine($"Aranan metnin ilk bulunduğu indeks: {indeks}");
            }
            else 
            {
                Console.WriteLine("Aranan metin bulunamadı.");
            }
        }
    }
}
