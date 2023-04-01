using CarRental.DataAccess;
using CarRental.Presentation.Interfaces;
using System;

namespace CarRental.Presentation
{
    internal class RegisterCarViewService : IViewService
    {
        private Car DefineACar()
        {
            Console.Clear();

            Console.WriteLine("Declare a brand of a car");
            var carBrand = Console.ReadLine();

            Console.WriteLine("Declare a color of a car");
            var carColor = Console.ReadLine();

            Console.WriteLine("Declare a production year of a car");
            var carProductionYear = GetYearOfProductionFromUser();

            Console.WriteLine("Declare a engine power");
            var carEnginePower = GetPowerEngineFromUser();

            Car car = new Car(carBrand, carColor, carProductionYear, carEnginePower);

            return car;
        }

        private int GetYearOfProductionFromUser()
        {
            string yearNow = DateTime.Now.ToString("yyyy");
            int yearNowNumber = Convert.ToInt32(yearNow);

            if (!int.TryParse(Console.ReadLine(), out int wasYearProvided))
                throw new Exception("You entered an invalid value.");

            if (wasYearProvided > yearNowNumber)
                throw new Exception("You entered a wrong year.");

            return wasYearProvided;
        }

        private int GetPowerEngineFromUser()
        {
            if (!int.TryParse(Console.ReadLine(), out int wasNumberProvided))
                throw new Exception("You entered an invalid value.");

            return wasNumberProvided;
        }

        public void Render()
        {
            var carFromUser = DefineACar();
            var repository = new CarsRepository();
            repository.Add(carFromUser);

            Console.WriteLine(
                $"Car {carFromUser.Brand}, " +
                $"{carFromUser.ProductionYear}, " +
                $"{carFromUser.Color}, " +
                $"{carFromUser.EnginePower} was registered.");
            Console.ReadKey();
        }
    }
}
