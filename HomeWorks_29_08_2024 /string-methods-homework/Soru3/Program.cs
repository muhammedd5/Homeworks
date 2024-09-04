namespace Soru3;

class Program
{
    static void Main(string[] args)

    
    {Console.WriteLine("Cümle giriniz");
    string cumle = Console.ReadLine();
    Console.WriteLine("Aranacak Kelime Giriniz:");
    string aranacakKelime = Console.ReadLine();
    string[] stringArr = cumle.Split(" ");
    int sayac =0;

    for(int i=0;i<stringArr.Length;i++){

    if(stringArr[i] == aranacakKelime){
        sayac ++;
    }

    }
    Console.WriteLine($"Aramış olduğunuz kelime cümlede {sayac} kez geçmiştir.");

    
    }
}
