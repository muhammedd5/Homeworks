using System;
using System.Globalization;

namespace TarihKarsilastirma
{
    class Program
    {
        static void Main(string[] args)
        {
            string format = "dd/MM/yyyy";

            Console.WriteLine($"Lütfen ilk tarihi '{format}' formatında giriniz:");
            string input1 = Console.ReadLine();
            
            Console.WriteLine($"Lütfen ikinci tarihi '{format}' formatında giriniz:");
            string input2 = Console.ReadLine();
           
            DateTime date1, date2;

            bool isDate1Valid = DateTime.TryParseExact(input1, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out date1);
            bool isDate2Valid = DateTime.TryParseExact(input2, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out date2);

            
            if (isDate1Valid && isDate2Valid)
            {
                if (date1 < date2)
                {
                    Console.WriteLine("İlk tarih, ikinci tarihten önce.");
                }
                else if (date1 > date2)
                {
                    Console.WriteLine("İlk tarih, ikinci tarihten sonra.");
                }
                else
                {
                    Console.WriteLine("İki tarih aynıdır.");
                }
            }
            else
            {
               
                Console.WriteLine("Girilen tarihlerden biri veya her ikisi geçersiz. Lütfen doğru formatta tarih giriniz.");
            }
        }
    }
}

