using System.Buffers;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Tracing;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Text.Encodings.Web;

namespace oop_homeworks;

class Animal
{
public string Name { get; set; }
public byte Age { get; set; }
public string Species { get; set; }

}

class Vehicle
{
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    
    public bool MyProperty { get; set; }



}

internal class Car : Vehicle 
{    public int NumberOfDoors { get; set; }

    class Employee
{
public string Name { get; set; }
public int ID { get; set; }
public decimal Salary { get; set; }
public decimal Manager { get; set; }

}
class Manager : Employee
{
public int NumberTeams { get; set; }
}
class Developer : Employee
{
    public string ProgrammingLanguage { get; set; }

}
class Intern : Employee
{
    public bool stajyer { get; set; }
}

class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Pages { get; set; }
    public int ISBN { get; set; }


}

class Borrow : Book
{
    public string borc { get; set; }
}
class Return : Book
{
    public string iade { get; set; }
}
class Event
{
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public string Location { get; set; }
    public bool Task { get; set; }
    
}
class Meeting : Event
{
    public string toplanti { get; set; }
}
class BirthDay : Event
{
    public DateTime birthDay { get; set; }
}
class Task : Event
{
    public bool MarkAsComplate { get; set; }
}

class Calculator
{
    public double Add { get ; set ; }

    public double Substract { get; set; }
    public double Multiply { get; set; }
    public double Divide { get; set; }

}

class Product 
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int StockQuantitiy { get; set; }


}
class Person
{
public string Name { get; set; }
public byte Age { get; set; }

class Teacher: Person
{
    public int SubjectTaught { get; set; }
    public string AttendClass { get; set; }
}
class Student: Person
{
    public int GradLevel { get; set; }
    public string AttendClass { get; set; }
}

}

class Program
{
    
    static void Main(string[] args)
    {
        // Product product1 = new Product()
        // {
        //     Name = "Tshirt",
        //     Price = 350,
        //     StockQuantitiy = 25

        // };
        // Product product2 = new Product()
        // {
        //     Name = "Shoe",
        //     Price = 1500,
        //     StockQuantitiy = 15

        // };
        
        // Product product3 = new Product()
        // {
        //     Name = "Bluz",
        //     Price = 150,
        //     StockQuantitiy = 50

        // };

        // Product[] products = {product1,product2,product3};
        // foreach (Product product in products)
        // {
        // Console.WriteLine($"{product.Name}- {product.Price}- {product.StockQuantitiy}");
        // }


    // Event[] events = {event1, event2, event3};
    // foreach (Event ev in events)
    //    {
    //     Console.WriteLine($"{ev.Name}- {ev.Date}-{ev.Location}- {ev.Task}");




    //     Calculator calculator1 = new Calculator()
    //     {
    //         Add = '+',
           
            
    //     };


    //     Calculator[] calculators = {calculator1};
    //     foreach (Calculator calculator in calculators)
    //     {
    //         Console.WriteLine($"{calculator1}");
    //     }



    //     Event event1 = new Event()
    //     {
    //         Name = "ÇGHB2",
    //         Date = DateTime.Now,
    //         Location = "BKM",
    //         Task = false
            
    //     };

    //     Event event2 = new Event()
    //     {
    //         Name = "Güldür Güldür Show",
    //         Date = DateTime.Now,
    //         Location = "BKM",
    //         Task = true
            
    //     };

    //     Event event3 = new Event()
    //     {
    //         Name = "Konuşanlar",
    //         Date = DateTime.Today,
    //         Location = "BKM",
    //         Task = false
    //     };

    // Event[] events = {event1, event2, event3};
    // foreach (Event ev in events)
    //    {
    //     Console.WriteLine($"{ev.Name}- {ev.Date}-{ev.Location}- {ev.Task}");
    //    }

        // Book book1 = new Book()
        // {
        //     Title = "Küçük Prens",
        //     Author = "Antoine",
        //     Pages = 132,
        //     ISBN = 920101010,

        // };
        // Book book2 = new Book()
        // {
        //     Title = "Hayvan Çiftliği",
        //     Author = "George Orwell",
        //     Pages = 132,
        //     ISBN = 920124320,

        // };
        // Book book3 = new Book()
        // {
        //     Title = "Sefiller",
        //     Author = "Victor Hugo",
        //     Pages = 162,
        //     ISBN = 920134350,
        // };

        // Book[] books = {book1, book2, book3};
        // foreach (Book book in books)
        // {
        //    Console.WriteLine($"{book.Title}- {book.Author}-{book.Pages}- {book.ISBN}");
        // }

        Car car1 = new Car()
        {

            Make = "Mercedes-Benz",
            Model = "G63",
            Year = 2024,
            NumberOfDoors = 2
        };

        Vehicle vehicle2 = new Vehicle()

        { Make = "KAWAZAKİ",
        Model = "Z02NM",
        Year = 2023
        
        };

        Vehicle vehicle3 = new Vehicle()
        {
        Make = "Kron",
        Model = "Olympus",
        Year = 2020

        };

        Vehicle[] vehicles = {car1, vehicle2, vehicle3};
        foreach (Vehicle vehicle in vehicles)
        {
            Console.WriteLine($"{vehicle.Make}- {vehicle.Model}-{vehicle.Year}");
        }


        {

            // Employee employee1 = new Employee()
            // {
            //     Name = "Ali",
            //     ID = 2000,
            //     Salary = 56700

            // };

            // Employee employee2 = new Manager()
            // {
            //     Name = "Ayşe",
            //     ID = 2223,
            //     Salary = 43555,
            //     NumberTeams = 21,
            // };
            // Employee employee3 = new Intern()
            // {
            //     Name = "Jony",
            //     ID = 2321,
            //     Salary = 10000,
            //     stajyer = true,

            // };
            // Employee[] employees = {employee1, employee2,employee3};
            // foreach (Employee employee in employees)
            // {
            //    Console.WriteLine($"{employee.Name}- {employee.ID}-{employee.Salary}");
            // }
            


        }

            // Animal animal1 = new Animal()
            // {
            //     Name = "Elephant",
            //     Age = 5,
            //     Species = "Africa Elephant"
            // };
            // Animal animal2 = new Animal()
            // {
            //     Name = "Lion",
            //     Age = 20,
            //     Species = "Africa Lion"
            // };
            // Animal animal3 = new Animal()
            // {
            //     Name = "Giraffe",
            //     Age = 3,
            //     Species = "Coloumbia Giraffe"
            // };

            // Animal[] animals = {animal1, animal2, animal3};
            // foreach (Animal animal in animals)
            // {
            //     Console.WriteLine($"{animal.Name}- {animal.Age}-{animal.Species}");
            // }

        }

        
        
 }   }

