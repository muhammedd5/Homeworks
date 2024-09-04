namespace Soru7;

class Program
{
    static void Main(string[] args)
    {
            Console.WriteLine("Bir açı giriniz (derece cinsinden): ");
            string girilenMetin = Console.ReadLine();

        
            if (double.TryParse(girilenMetin, out double derece))
            {
              
                double radyan = derece * (Math.PI / 180);

                
                Console.WriteLine($"Açının radyan cinsinden değeri: {radyan}");
            }
            else
            {
                
                Console.WriteLine("Geçerli bir açı değeri giriniz.");
            }
        }
    }

