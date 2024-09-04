using System.Globalization;

namespace Soru7;

class Program
{
    static void Main(string[] args)
    {
        string format = "dd/MM/yyyy";
        CultureInfo provider = CultureInfo.InvariantCulture;

        Console.WriteLine($"Lütfen bir tarihi {format} formatında giriniz:");


        string input = Console.ReadLine();
        
       
        DateTime parsedDate;
        
        
        if (DateTime.TryParseExact(input, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate))
        {
           
            Console.WriteLine("Girilen tarih: " + parsedDate.ToString(format));
        }
        else
        {
          
            Console.WriteLine("Geçersiz tarih formatı. Lütfen 'dd/MM/yyyy' formatında tarih girin.");
        }
    }
    }

