namespace Soru3;

class Program
{
    static void Main(string[] args)
    {
        double sayı1, sayı2, sonuç;
        char işlem;

        Console.Write("Birinci sayıyı girin: ");
        sayı1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("İkinci sayıyı girin: ");
        sayı2 = Convert.ToDouble(Console.ReadLine());

        Console.Write("İşlem seçin (+, -, *, /): ");
        işlem = Console.ReadLine()[0]; 
    
        switch (işlem)
        {
            case '+':
                sonuç = sayı1 + sayı2;
                Console.WriteLine($"Sonuç: {sayı1} + {sayı2} = {sonuç}");
                break;
            case '-':
                sonuç = sayı1 - sayı2;
                Console.WriteLine($"Sonuç: {sayı1} - {sayı2} = {sonuç}");
                break;
            case '*':
                sonuç = sayı1 * sayı2;
                Console.WriteLine($"Sonuç: {sayı1} * {sayı2} = {sonuç}");
                break;
            case '/':
                if (sayı2 != 0)
                {
                    sonuç = sayı1 / sayı2;
                    Console.WriteLine($"Sonuç: {sayı1} / {sayı2} = {sonuç}");
                }
                else
                {
                    Console.WriteLine("Hata: Sıfıra bölme hatası!");
                }
                break;
            default:
                Console.WriteLine("Geçersiz işlem seçimi.");
                break;
        }
    }
}


