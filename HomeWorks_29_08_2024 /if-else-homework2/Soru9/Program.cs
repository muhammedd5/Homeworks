using System;

namespace Soru9
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bir yıl giriniz:");
            int year = int.Parse(Console.ReadLine());

            if (IsLeapYear(year))
            {
                Console.WriteLine($"{year} bir artık yıldır.");
            }
            else
            {
                Console.WriteLine($"{year} bir artık yıl değildir.");
            }
        }
        static bool IsLeapYear(int year)
        {
           
            if (year % 4 == 0)
            {

                if (year % 100 == 0)
                {
                    return year % 400 == 0;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
    }
}

