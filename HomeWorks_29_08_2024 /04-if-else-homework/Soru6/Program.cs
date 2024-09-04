using System;

namespace Soru6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Notunuzu giriniz (0-100 arasında bir değer): ");
            if (!double.TryParse(Console.ReadLine(), out double grade))
            {
                Console.WriteLine("Geçersiz bir değer girdiniz. Lütfen bir sayı girin.");
                return;
            }

            if (grade < 0 || grade > 100)
            {
                Console.WriteLine("Geçersiz bir not girdiniz. Lütfen 0 ile 100 arasında bir değer girin.");
            }
            else
            {
                string letterGrade = GetLetterGrade(grade);
                Console.WriteLine($"Notunuzun harf karşılığı: {letterGrade}");
            }
        }

        static string GetLetterGrade(double grade)
        {
            if (grade >= 90)
                return "AA";
            else if (grade >= 85 && grade < 90)
                return "BA";
            else if (grade >= 80 && grade < 85)
                return "BB";
            else if (grade >= 70 && grade < 80)
                return "CB";
            else if (grade >= 60 && grade < 70)
                return "CC";
            else if (grade >= 55 && grade < 60)
                return "DC";
            else if (grade >= 50 && grade < 55)
                return "DD";
            else if (grade >= 40 && grade < 50)
                return "FD";
            else
                return "FF";
        }
    }
}
