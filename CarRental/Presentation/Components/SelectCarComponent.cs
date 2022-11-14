using System;
using System.Collections.Generic;

namespace CarRental.Presentation.Components
{
    public class SelectCarComponent
    {
        public Car GetCarWithTemporaryId(List<Car> cars, string carActivity)
        {
            Console.WriteLine($"Cars you can {carActivity}: ");
            foreach (var car in cars)
            {
                Console.Write(
                    $"\n{cars.IndexOf(car) + 1}: " +
                    $"Id of a car: {car.Id} " +
                    $"\nBrand: {car.Brand}, " +
                    $"\nProduction Year: {car.ProductionYear}, " +
                    $"\nColor: {car.Color}, " +
                    $"\nEngine Power: {car.EnginePower}" +
                    $"\n----------------\n");
            }

            while(true)
            {
                Console.WriteLine($"Enter an index of a car you want to {carActivity}");

                if (!int.TryParse(Console.ReadLine(), out int carTemporaryId))
                {
                    Console.WriteLine("You entered an invalid value.");
                    continue;
                }

                var neededCar = cars.Find(c => cars.IndexOf(c) == carTemporaryId - 1);

                if (neededCar == null)
                {
                    Console.WriteLine("You entered an invalid value.");
                    continue;
                }                  

                return neededCar;
            }            
        }
    }
}
