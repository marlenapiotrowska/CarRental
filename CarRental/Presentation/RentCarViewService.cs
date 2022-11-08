using CarRental.DataAccess;
using CarRental.Domain;
using CarRental.Domain.Models;
using CarRental.Presentation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRental.Presentation
{
    public class RentCarViewService : IViewServiceWithParameter
    {
        public void Render(Car car)
        {
            var service = new CarService();
            service.Rent(car);

            Console.WriteLine($"Car {car.Brand}, " +
                $"{car.ProductionYear}, " +
                $"{car.Color}, " +
                $"{car.EnginePower} was rent.");
        }

        public void WriteWantedCarToRent()
        {
            Console.WriteLine("Enter a brand of a car you want to rent");
            string wantedCarBrand = Console.ReadLine();

            var repository = new CarsRepository();
            var cars = repository.GetAvailable();
            var carWithWantedBrand = cars
                .Where(c => c.Brand == wantedCarBrand);

            if (carWithWantedBrand.Count() == 0)
                Console.WriteLine("There is no car meets your expectations.");

            else
            {
                foreach (var car in carWithWantedBrand)
                {
                    Console.WriteLine($"Available cars: " +
                        $"{car.Id} {car.Brand}, {car.ProductionYear}, {car.Color}, {car.EnginePower}.");
                }

                int productionYear = GetProductionYear(); 
                
                var carWantedToBeRent = cars
                    .Where(c => c.ProductionYear == productionYear).First();                

                Render(carWantedToBeRent);
            }

            Console.ReadKey();
        }

        public int GetProductionYear()
        {
            Console.WriteLine("Enter production year of a car you want to rent.");

            if (!int.TryParse(Console.ReadLine(), out int carProductionYear))
                Console.WriteLine("You entered an invalid value.");

            return carProductionYear;
        }       
    }
}
