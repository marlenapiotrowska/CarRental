using CarRental.DataAccess;
using CarRental.Domain;
using CarRental.Presentation.Components;
using CarRental.Presentation.Interfaces;
using System;
using System.Linq;

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
                .Where(c => c.Brand == wantedCarBrand)
                .ToList();

            if (carWithWantedBrand == null)
                Console.WriteLine("There is no car meets your expectations.");

            else
            {
                var component = new SelectCarComponent();
                var carWantedToBeReturn = component.GetCarWithTemporaryId(carWithWantedBrand, "return");
                Render(carWantedToBeReturn);
            }

            Console.ReadKey();
        }
    }  
}
