using CarRental.DataAccess;
using CarRental.Presentation.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;


namespace CarRental.Presentation
{
    internal class DisplayCarsViewService : IViewService
    {
        public void Render()
        {
            var repository = new CarsRepository();
            var cars = repository.GetAvailable();

            foreach(var car in cars)
            {
                Console.WriteLine(
                    $"\nIndex of a car: Car{cars.IndexOf(car) + 1}" +
                    $"\nBrand:{car.Brand}," +
                    $"\nProduction year: {car.ProductionYear}, " +
                    $"\nColor: {car.Color}, " +
                    $"\nEngine power: {car.EnginePower}" +
                    $"\n----------------");
            }

            Console.ReadKey();
        }
    }
}
