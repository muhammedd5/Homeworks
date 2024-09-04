namespace Soru8;

class Program
{
    static void Main(string[] args)
    {
    
{
        Console.Write("Doğum yılınızı giriniz: ");
        int yil;
        bool validInput = int.TryParse(Console.ReadLine(), out yil);

        if (!validInput || yil < 0)
        {
            Console.WriteLine("Geçersiz bir yıl girdiniz. Lütfen geçerli bir yıl giriniz.");
            return;
        }

        
        string burc = CinsZodyagiBurcu(yil);
        Console.WriteLine($"Doğum yılınız olan {yil} yılına göre Çin Zodyağı burcunuz: {burc}");
    }

    static string CinsZodyagiBurcu(int yil)
    {
        string[] zodyagi = {
            "Fare", "Sığır", "Kaplan", "Tavşan", "Ejderha", 
            "Yılan", "At", "Koyun", "Maymun", "Horoz", 
            "Köpek", "Domuz"
        };

        int index = yil % 12;
        return zodyagi[index];
    }
}

    }

