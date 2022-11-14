using CarRental.DataAccess;
using CarRental.Domain;
using CarRental.Presentation.Components;
using CarRental.Presentation.Interfaces;
using System;
using System.Linq;


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
                .Where(c => c.Brand == wantedCarBrand)
                .ToList();

            if (carWithWantedBrand.Count() == 0)
                Console.WriteLine("There is no car meets your expectations.");

            else
            {
                var component = new SelectCarComponent();
                var carWantedToBeRent = component.GetCarWithTemporaryId(carWithWantedBrand, "rent");
                Render(carWantedToBeRent);
            }
            Console.ReadKey();
        }
              
    }
}
