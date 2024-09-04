using System;

namespace Soru4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Bir harf girin: ");
            char harf = Console.ReadKey().KeyChar;
            Console.WriteLine(); 

            harf = Char.ToLower(harf);
            
            if (Char.IsLetter(harf))
            {
                if (IsSesliHarf(harf))
                {
                    Console.WriteLine("Sesli harf");
                }
                else
                {
                    Console.WriteLine("Sessiz harf");
                }
            }
            else
            {
                Console.WriteLine("Geçerli bir harf girilmedi.");
            }
        }

        static bool IsSesliHarf(char harf)
        {
            char[] sesliHarfler = { 'a', 'e', 'ı', 'i', 'o', 'ö', 'u', 'ü' };
            foreach (char sesli in sesliHarfler)
            {
                if (harf == sesli)
                {
                    return true;
                }
            }
            return false;
        }
    }
}

