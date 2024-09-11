using System.Globalization;
using System.Xml.Schema;

namespace _01_arrays_homework;

class Program
{
    static void Main(string[] args)


    
    //    1. 10 elemanlı rastgele değerlerden oluşan bir tam sayı dizisi içinde, dizinin her bir elemanının yalnızca bir önceki ve bir sonraki elemanı ile kıyaslandığı bir algoritma yazın. Bu algoritma, yalnızca kendinden önceki sayı ve kendinden sonraki sayı büyük olan elemanları bulmalı ve bunları ekrana yazdırmalıdır.

    //  {
    //     int[] numbers = {50, 34, 53, 324, 432, 452, 848, 700, 234, 543};

        
    //     for (int i = 1; i < numbers.Length - 1; i++)
    //     {   
            
    //     if (numbers[i] > numbers[i - 1] && numbers[i] > numbers[i + 1])
    //     {
               
    //         Console.WriteLine(numbers[i]);
    //         }
    //     }
    // }

   
   
//    2. Klavyeden girilen 10 sayıyı bir diziye atayın. Bu sayılardan çift olanları for döngüsü kullanarak ayrı bir diziye aktarın. Ardından bu çift sayı dizisini küçükten büyüğe sıralayın.

    // {
    //     int[] sayi = new int[10];
    //     Console.WriteLine("Lütfen 10 tane sayı girin:");

    //     for (int i = 0; i < sayi.Length; i++)
    //     {
    //         Console.Write($"Sayı {i + 1}: ");
    //         sayi[i] = Convert.ToInt32(Console.ReadLine());
    //     }

    //     int[] ciftSayilar = new int[sayi.Length];
    //     int ciftSayilarSayisi = 0;

    //     for (int i = 0; i < sayi.Length; i++)
    //     {
    //         if (sayi[i] % 2 == 0)
    //         {
    //             ciftSayilar[ciftSayilarSayisi] = sayi[i];
    //             ciftSayilarSayisi++;
    //         }
    //     }

    //     Array.Resize(ref ciftSayilar, ciftSayilarSayisi);

    //     int[] siraliCiftSayilar = ciftSayilar.OrderBy(x => x).ToArray();

    //     Console.WriteLine("Çift sayılar (küçükten büyüğe sıralanmış):");
    //     foreach (int sayilar in siraliCiftSayilar)
    //     {
    //         Console.WriteLine(sayi);
    //     }
    // }

    // 3. 10 elemanlı rastgele değerlerden oluşan bir dizideki tüm pozitif sayıları ve negatif sayıları ayrı dizilere ayıran ve her iki diziyi de ekrana yazdıran bir program yazın. İşlemi gerçekleştirmek için while döngüsü kullanın.
    


// {
//     static void Main()
//     {
//         Random rnd = new Random();
//         int[] array = new int[10];
//         int[] positiveArray = new int[10];
//         int[] negativeArray = new int[10];

//         int positiveCount = 0;
//         int negativeCount = 0;

//         int i = 0;
//         while (i < array.Length)
//         {
//             array[i] = rnd.Next(-100, 101);
//             i++;
//         }

//         i = 0;
//         while (i < array.Length)
//         {
//             if (array[i] > 0)
//             {
//                 if (positiveCount < positiveArray.Length) 
//                 {
//                     positiveArray[positiveCount] = array[i];
//                     positiveCount++;
//                 }
//             }
//             else if (array[i] < 0)
//             {
//                 if (negativeCount < negativeArray.Length) 
//                 {
//                     negativeArray[negativeCount] = array[i];
//                     negativeCount++;
//                 }
//             }
//             i++;
//         }

//         Console.WriteLine("Orjinal Dizi: ");
//         foreach (int num in array)
//         {
//             Console.Write(num + " ");
//         }
//         Console.WriteLine();

//         Console.WriteLine("Pozitif sayılar:");
//         for (i = 0; i < positiveCount; i++)
//         {
//             Console.Write(positiveArray[i] + " ");
//         }
//         Console.WriteLine();

//         Console.WriteLine("Negatif sayılar:");
//         for (i = 0; i < negativeCount; i++)
//         {
//             Console.Write(negativeArray[i] + " ");
//         }
//         Console.WriteLine();
//     }
// }

// {
        //  4. 100 elemanlı rastgele değerlerden oluşan bir tam sayı dizisinde tekrar eden elemanları bulan bir program yazın. Diziyi tararken, elemanların hangi pozisyonlarda(kaçıncı indexte) tekrarlandığını ekrana yazdırın. Bu işlemi hem for hem de foreach döngüleri ile gerçekleştirin.

        
//         Random rnd = new Random();
//         int[] array = new int[100];

        
//         for (int i = 0; i < array.Length; i++)
//         {
//             array[i] = rnd.Next(1, 101); 
//         }

        
//         Dictionary<int, List<int>> occurrences = new Dictionary<int, List<int>>();

        
//         for (int i = 0; i < array.Length; i++)
//         {
//             if (occurrences.ContainsKey(array[i]))
//             {
//                 occurrences[array[i]].Add(i);
//             }
//             else
//             {
//                 occurrences[array[i]] = new List<int> { i };
//             }
//         }

       
//         Console.WriteLine("Tekrar eden elemanlar (for döngüsü ile):");
//         foreach (var entry in occurrences)
//         {
//             if (entry.Value.Count > 1)
//             {
//                 Console.Write($"Eleman: {entry.Key} - Pozisyonlar: ");
//                 foreach (var pos in entry.Value)
//                 {
//                     Console.Write(pos + " ");
//                 }
//                 Console.WriteLine();
//             }
//         }

//     }

// }

    // 5. Klavyeden girilen bir sayının, 100 elemanlı rastgele değerlerden oluşan bir tam sayı dizisinde olup olmadığını kontrol eden bir algoritma yazın. Eğer sayı dizide varsa, sayının dizideki yerini ve tekrar sayısını ekrana yazdırın.



// {
//   Random rnd = new Random();
//   int[] numbers = new int[100];

//   for (int i = 0; i < numbers.Length; i++)
//   {
//     numbers[i] = rnd.Next(1, 101);
//   }

//   Console.WriteLine("Sayı giriniz: ");
//   int userInput = int.Parse(Console.ReadLine());

//   int count = 0;
//   int[] indices = new int [numbers.Length];

//   for (int i = 0; i < numbers.Length; i++)

//   {
//     if (numbers[i] == userInput)

//     {
//       indices[count] = i;
//       count ++;
//     }
//   }

//   if (count > 0)

//   {
//    Console.WriteLine($"{userInput} sayısı dizide {count} kez bulunuyor.");
//   Console.WriteLine("Bulunduğu indeksler:");

//   for (int i = 0; i < count; i++)
//   {
//     Console.WriteLine(indices[i]);
//   }
  // }
  // else
  // {
  //   Console.WriteLine($"{userInput} sayısı dizide bulunmuyor.");
  // }

// 6. 100 elemanlı rastgele değerlerden oluşan bir tam sayı dizisinde en büyük ve en küçük sayıyı bulan programı yazın.
// {
//   Random rnd = new Random();
//   int [] numbers = new int [100];

//   for (int i = 0; i < numbers.Length; i++)
//   {
//     numbers[i] = rnd.Next(1, 1001);
  
//   }

//   int min = numbers[0];
//   int max = numbers[0];

//   for (int i = 1; i < numbers.Length; i++)
//   {
//     if (numbers[i] < min)
//     {
//       min = numbers[i];
//     }

//     if (numbers[i] > max)
//     {
//       max = numbers[i];
//     }
//   }

//   Console.WriteLine("En küçük sayı:" + min );
//   Console.WriteLine("En büyük sayı:" + max );

// }


// {

  // Random rnd = new Random();
  // int[] numbers = new int[100];

  // for (int i = 0; i < numbers.Length; i++)
  // {
  //   numbers [i] = rnd.Next(1, 51);

  // }

  // int toplamc = 0;

  // foreach (int number in numbers)
  // {
  //   if (number % 2 == 0)
  //   {
  //     toplamc += number;
  //   }
  // }

  // Console.WriteLine("Dizideki çift sayıların toplamı: " + toplamc);
   

// }

// 8. Klavyeden girilen bir sayıyı, 10 elemanlı rastgele değerlerden oluşan bir tam sayı dizisinde aratın. Eğer sayı dizide yoksa, diziyi sıralayın ve sayıyı dizinin doğru(olması gereken sıra) yerine ekleyin. Ekledikten sonra yeni diziyi ekrana yazdırın.

// {

// Random rnd = new Random();
// int[] numbers = new int[10];

// for (int i = 0; i < numbers.Length; i++)
// {
//   numbers [i] = rnd.Next(1, 101);
// }

//  Console.WriteLine("Dizi: " + string.Join(",", numbers));

//  Console.WriteLine("Bir sayı girin: ");
//  if (!int.TryParse(Console.ReadLine(), out int sayi))
//  {
//   Console.WriteLine("Geçersiz giriş.");
//   return;
//  }

//  bool varMi = false;
//  for (int i = 0; i < numbers.Length; i++)
//  {
//   if (numbers[i] == sayi)
//   {
//     varMi = true;
//     break;
//   }
  
//  }
//  if (!varMi) 
//  {

//   Array.Sort(numbers);
//   int[] newNumbers = new int[numbers.Length + 1];
//   bool eklendi = false;
//   int j = 0;
//   for (int i = 0; i < newNumbers.Length; i++)
// {
//   if (j < numbers.Length && (numbers[j] < sayi || eklendi))
//   {
//   newNumbers[i] = numbers[j];
//   j++;
// }
//   else
// {
// newNumbers[i] = sayi;
// eklendi = true;
// }
// }
//  }


// }

// 9. Verilen bir dizinin yalnızca pozitif sayılarını ters çeviren bir algoritma yazın. Diziyi tararken, sadece pozitif sayıların yerini değiştirmelisiniz, diğer elemanlar aynı kalmalı.

// {
// int[] dizi = { 6, -4, 3, -6, -23, 34, 54};

// List<int> pozitifSayilar = new List<int> ();

// foreach (int eleman in dizi)
// {
//   if ((eleman> 0))

//   {
//     pozitifSayilar.Add(eleman);
//   }
  
// }

// pozitifSayilar.Reverse();

// int pozitifIndex = 0;

// for (int i = 0; i < dizi.Length; i++)
// {
// if (dizi[i] > 0)
// {
// dizi[i] = pozitifSayilar[pozitifIndex++];
// }
// }

// Console.WriteLine("Sonuç Dizi: " + string.Join(", ", dizi));

// }

// 10. 10 elemanlı bir dizi oluşturun ve bu dizinin elemanlarını bir başka diziye ters sırada kopyalayın. İlk dizideki sıralama değişmeyecek, sadece ikinci dizideki sıralama ters olacak.

// {

// int[] ilkDizi = new int[10];
// Random rnd = new Random();

// for (int i = 0; i < ilkDizi.Length; i++)
// {
//   ilkDizi[i] = rnd.Next(1, 101);

// }

// Console.WriteLine("İlk Dizi: " + string.Join(", ", ilkDizi));

// int[] ikinciDizi = new int[10];

// for (int i = 0; i < ilkDizi.Length; i++)
// {
//   ikinciDizi[i] = ilkDizi[ilkDizi.Length - 1 - i];
// }

// Console.WriteLine("ikinci dizi : " + string.Join(",", ikinciDizi));

//   

// 11. Klavyeden girilen bir cümlenin kelimelerini bir diziye aktarın. while döngüsü ile bu kelimeleri tersten ekrana yazdırın.
// {
//     {
   
//     Console.Write("Bir cümle girin: ");
//     string sentence = Console.ReadLine();

      
//     string[] words = sentence.Split(' ');

//     int index = words.Length - 1;
//     while (index >= 0)
//      {
//       Console.WriteLine(words[index]);
//       index--;
//      }
//     }
// }

// 12. 100 elemanlı rastgele değerlerden oluşan bir tam sayı dizisinde en sık tekrar eden elemanı bulan ve kaç defa tekrarlandığını ekrana yazdıran bir program yazın. Bu işlemi bir foreach döngüsü ile gerçekleştirin.

// {

//   Random rnd = new Random();

//   int [] numbers = new int[100];

//   for (int i = 0; i < numbers.Length; i++)
//   {
//     numbers[i] = rnd.Next(1, 1001);
  
//   }
//   ***********Yapamadım**********
// }

// 13. Bir dizideki tek sayıları toplayan ve bu toplamın çift mi, tek mi olduğunu kontrol eden bir program yazın. Toplamla birlikte eğer toplam tek ise, "Toplam tek sayı" mesajı, çift ise "Toplam çift sayı" mesajı ekrana yazdırılmalı.

// {
// int [] numbers = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
// int sayilar = 0;

// foreach (int number in numbers)
// {
// if (number % 2 != 0)
// {
//   sayilar += number;
// }

// }

// if (sayilar % 2 == 0)
// {
// Console.WriteLine($"Toplam çift sayı: {sayilar}");
// }
// else
// {
//   Console.WriteLine($"Toplam çift sayı: {sayilar}");
// }

// }

// 14. 20 elemanlı bir dizi oluşturun. Bu dizideki elemanların 3’e bölünebilenlerin toplamını bulan bir algoritma yazın. Sonucu ekrana yazdırırken her 5. elemandan sonra bir boşluk bırakın.

// {
//   Random rnd = new Random();
// int [] numbers = new int[20];

// for (int i = 0; i < numbers.Length; i++)
// {
//   numbers[i] = rnd.Next(1, 101);

// }

// int bolumuc = 0;

// foreach (int number in numbers)
// {
//   if (number % 3 == 0)
//   {
//     bolumuc += number;
//   }
// }

// Console.WriteLine("3'e bölünebilen sayılar: ");

// int count = 0;
// foreach (int number in numbers)
// {
//   if (number % 3 == 0)
//   {
//     Console.WriteLine(number + " ") ; count++;
//     if (count % 5 == 0)
//     {
//    Console.WriteLine(" ");
//     }
//   }

// }
// Console.WriteLine($"\n3'e bölünebilen sayıların toplamı: {bolumuc}");

// }

// 15. Bir dizideki elemanları küçükten büyüğe sıralayan bir algoritma yazın. Ancak sıralama sırasında sadece tek sayılar sıralanmalı, çift sayılar yerlerinde kalmalıdır.


// {

// int[] numbers = {1, 3, 5, 4, 8, 9, 2, 7, 6};

// var tekSayi = numbers.Where(n => n % 2 != 0).ToList();

// tekSayi.Sort();

// int tekIndex = 0;

// int[] sortedNumbers = new int[numbers.Length];

// for (int i = 0; i < numbers.Length; i++)
// {
//   if (numbers[i] % 2 == 0)
//   {
//     sortedNumbers[i] = numbers[i];
//   }

//   else
//   {
//     sortedNumbers[i] = tekSayi[tekIndex];
//     tekIndex++;
//   }
// }

// Console.WriteLine("Dizideki elemanları küçükten büyüğe sıralama (sadece tek sayılar): ");

// foreach (int number in sortedNumbers)
// {
//   Console.WriteLine(number + " ");
// }



// }
// 16. do-while döngüsü kullanarak, klavyeden girilen sayıları bir diziye ekleyin. Kullanıcı sıfır girdiğinde döngüden çıkın ve dizideki tüm sayılarla birlikte ortalamayı ekrana yazdırın.



// {

//   var numbers = new System.Collections.Generic.List<int>();
        
//   int input;
        
    
//   do
// {
//  Console.Write("Bir sayı girin (durdurmak için 0 girin): ");
// input = Convert.ToInt32(Console.ReadLine());
            
// if (input != 0)
// {
// numbers.Add(input); 
// }
// } while (input != 0);
        
// if (numbers.Count > 0)
// {
//   int sum = 0;
//   foreach (int number in numbers)
//   {
// sum += number;
// }
            
//  double average = (double)sum / numbers.Count;
            

// Console.WriteLine("Girilen sayılar:");
// foreach (int number in numbers)
//  {
// Console.Write(number + " ");
// }
// Console.WriteLine();
// Console.WriteLine($"Ortalama: {average}");
// }
//  else
//  {
//  Console.WriteLine("Hiçbir sayı girilmedi.");
// }
// }


// 17. Bir dizideki en büyük iki sayıyı bulan bir program yazın. Bu programı bir for döngüsü ile yazın, ancak aynı sayının iki defa en büyük olarak seçilmesine izin vermeyin.

// {

// int[] arr = { 12, 34, 3, 10, 39, 1 };
        
// try
// {
// (int largest, int secondLargest) = FindTwoLargestNumbers(arr);
// Console.WriteLine("En büyük iki sayı: {0} ve {1}", largest, secondLargest);
// }
// catch (Exception ex)
// {
// Console.WriteLine(ex.Message);
//  }
// }

//  static (int, int) FindTwoLargestNumbers(int[] arr)
// {
//  if (arr.Length < 2)
// {
// throw new ArgumentException("Dizi en az iki elemandan oluşmalıdır.");
// }

// int largest = int.MinValue;
// int secondLargest = int.MinValue;

// foreach (int num in arr)
// {
// if (num > largest)
// {
              
// secondLargest = largest;
//  largest = num;
// }
//  else if (num > secondLargest && num < largest)
// {
//  secondLargest = num;
// }
// }

// if (secondLargest == int.MinValue)
//         {
//             throw new ArgumentException("Dizi en az iki farklı eleman içermelidir.");
//         }

//         return (largest, secondLargest);
//     }
// }
