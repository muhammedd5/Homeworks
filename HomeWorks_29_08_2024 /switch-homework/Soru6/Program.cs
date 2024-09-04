namespace Soru6;

class Program
{
    
        static void Main(string[] args)
        {
            Console.Write("Bir not girin (A, B, C, D, F): ");
            char not = Char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine();

            if (not == 'A' || not == 'B' || not == 'C' || not == 'D' || not == 'F')
            {
                string durum = BelirleDurum(not);
                Console.WriteLine($"Notanız: {not}");
                Console.WriteLine($"Durum: {durum}");
            }
            else
            {
                Console.WriteLine("Geçerli bir nota girilmedi.");
            }
        }

        static string BelirleDurum(char not)
        {
            switch (not)
            {
                case 'A':
                case 'B':
                case 'C':
                    return "Geçme";
                case 'D':
                    return "Geçebilir";
                case 'F':
                    return "Kalma";
                default:
                    return "Geçersiz nota";
            }
        }
    }

