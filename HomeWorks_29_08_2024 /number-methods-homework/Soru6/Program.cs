namespace Soru6;

        static void Main(string[] args)
        {
          
            Console.WriteLine("Bir açı giriniz (derece cinsinden): ");
            string girilenMetin = Console.ReadLine();

           
            if (double.TryParse(girilenMetin, out double derece))
            {
                double radyan = derece * (Math.PI / 180);

                double sinusDegeri = Math.Sin(radyan);

            
                Console.WriteLine($"Açının sinüs değeri: {sinusDegeri}");
            }
            else
            {
                
                Console.WriteLine("Geçerli bir açı değeri giriniz.");
            }
        }
    
