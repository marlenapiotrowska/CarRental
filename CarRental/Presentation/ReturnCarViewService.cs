using CarRental.DataAccess;
using CarRental.Domain;
using CarRental.Presentation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRental.Presentation
{
    public class ReturnCarViewService : IViewServiceWithParameter
    {
        public void Render(Car car)
        {
            var service = new CarService();
            service.Return(car);

            Console.WriteLine($"Car {car.Brand}, " +
                $"{car.ProductionYear}, " +
                $"{car.Color}, " +
                $"{car.EnginePower} was returned.");
        }
        public void WriteWantedCarToReturn()
        {
            Console.WriteLine("Enter a brand of a car you want to return");
            string wantedCarBrand = Console.ReadLine();

            var repository = new CarsRepository();
            var cars = repository.GetUnavailable();
            var carWithWantedBrand = cars
                .Where(c => c.Brand == wantedCarBrand);

            if (carWithWantedBrand == null)
                Console.WriteLine("There is no car meets your expectations.");

            else
            {
                foreach (var car in carWithWantedBrand)
                {
                    Console.WriteLine($"Rented car: " +
                        $"{car.Id} {car.Brand}, {car.ProductionYear}, {car.Color}, {car.EnginePower}.");
                }

                int productionYear = GetProductionYear();               

                var carWantedToBeReturn = cars
                    .Where(c => c.ProductionYear == productionYear).First();

                Render(carWantedToBeReturn);
            }

            Console.ReadKey();
        }

        public int GetProductionYear()
        {
            Console.WriteLine("Enter production year of a car you want to return.");

            if (!int.TryParse(Console.ReadLine(), out int carProductionYear))
                throw new Exception("You entered an invalid value.");

            return carProductionYear;
        }       
    }
}
