namespace Soru8;

class Program
{
    static void Main(string[] args)
    {
            Console.WriteLine("Bir sayı giriniz: ");
            if (!int.TryParse(Console.ReadLine(), out int number))
            {
                Console.WriteLine("Geçersiz bir sayı girdiniz.");
                return;
            }

            
            bool divisibleBy3 = number % 3 == 0;
            bool divisibleBy5 = number % 5 == 0;

            
            if (divisibleBy3 && divisibleBy5)
            {
                Console.WriteLine("Sayı hem 3'e hem de 5'e tam bölünüyor.");
            }
            else if (divisibleBy3)
            {
                Console.WriteLine("Sayı 3'e tam bölünüyor ancak 5'e bölünmüyor.");
            }
            else if (divisibleBy5)
            {
                Console.WriteLine("Sayı 5'e tam bölünüyor ancak 3'e bölünmüyor.");
            }
            else
            {
                Console.WriteLine("Sayı ne 3'e ne de 5'e tam bölünüyor.");
            }
        } 
    }

