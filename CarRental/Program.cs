using CarRental.Presentation;
using System;
using System.Collections.Generic;

namespace CarRental
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var viewService = new MenuViewService();
            viewService.Render();


        //    CarRental JacksRental = new CarRental();
        //    var car1 = new Car("Nissan", "żółty", 2005, 90);
        //    var car2 = new Car("Fiat", "niebieski", 2015, 88);
        //    var car3 = new Car("Fiat", "zielony", 2020, 120);
        //    JacksRental.Register(car1);
        //    JacksRental.Register(car2);
        //    JacksRental.Register(car3);

        //    while (true)
        //    {
        //        Console.Clear();

        //        Console.WriteLine(
        //        "------------- Hello in Car Rental -------------" +
        //        "\nPress the button:" +
        //        "\n[1] To register new car" +
        //        "\n[2] To rent a car" +
        //        "\n[3] To ride a car" +
        //        "\n[4] To see available cars" +
        //        "\n[5] To quit");                                
                
        //        var usersCommand = Console.ReadLine();

        //        if (usersCommand == "1")
        //        {
        //            Console.Clear();
        //            Car carx = DefineACar();
        //            JacksRental.Register(carx);                    
        //        }
        //        else if (usersCommand == "2")
        //        {
        //            Console.Clear();
        //            JacksRental.WriteWantedCarToRent();                                 
        //        }
        //        else if (usersCommand == "3")
        //        {
        //            Console.Clear();
        //            JacksRental.WriteWantedCarToRide();                    
        //        }
        //        else if (usersCommand == "4")
        //        {
        //            Console.Clear();
        //            JacksRental.WriteCarsToConsole();
        //            Console.WriteLine("Press any button go back");
        //            Console.ReadKey();
        //        }
        //        else if (usersCommand == "5")
        //        {
        //            break;
        //        }
        //        else
        //        {
        //            throw new InvalidOperationException("You pressed an invalid number");
        //        }
        //    }
        //}
        //private static Car DefineACar()
        //{
        //    Console.Clear();

        //    Console.WriteLine("Declare a brand of a car");
        //    var carBrand = Console.ReadLine();

        //    Console.WriteLine("Declare a color of a car");
        //    var carColor = Console.ReadLine();

        //    Console.WriteLine("Declare a production year of a car");
        //    var carProductionYear = GetYearOfProductionFromUser();

        //    Console.WriteLine("Declare a engine power");
        //    var carEnginePower = GetPowerEngineFromUser();

        //    Car car = new Car(carBrand, carColor, carProductionYear, carEnginePower);

        //    return car;
        //}
        //private static int GetYearOfProductionFromUser()
        //{
        //    string yearNow = DateTime.Now.ToString("yyyy");
        //    int yearNowNumber = Convert.ToInt32(yearNow);

        //    if (!int.TryParse(Console.ReadLine(), out int wasYearProvided))
        //        throw new Exception("You entered an invalid value.");

        //    if (wasYearProvided > yearNowNumber)
        //        throw new Exception("You entered a wrong year.");

        //    return wasYearProvided;
        //}
        //private static int GetPowerEngineFromUser()
        //{
        //    if (!int.TryParse(Console.ReadLine(), out int wasNumberProvided))
        //        throw new Exception("You entered an invalid value.");

        //    return wasNumberProvided;
        }
    }
}
