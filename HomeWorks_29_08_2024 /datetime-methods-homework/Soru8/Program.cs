using System;
using System.Globalization;

namespace Soru8
{
    class Program
    {
        static void Main(string[] args)
        {
            
            DateTime now = DateTime.Now;

            string monthName = now.ToString("MMMM", CultureInfo.CurrentCulture);

            Console.WriteLine("Bu ayın adı: " + monthName);
        }
    }
}
