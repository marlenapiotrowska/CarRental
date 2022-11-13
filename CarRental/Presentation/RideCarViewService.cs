using CarRental.DataAccess;
using CarRental.Domain;
using CarRental.Domain.Models;
using CarRental.Presentation.Components;
using CarRental.Presentation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRental.Presentation
{
    public class RideCarViewService : IViewServiceWithParameter
    {
        public void Render(Car car)
        {            
            var service = new CarService();
            service.Ride(car);
            RideACar();
            service.StopRide(car);
        }

        public void RideACar()
        {
            bool shouldIRide = true;
            int speed = 0;
            DriveDirection actualDirection = DriveDirection.None;
            var historyOfaRide = new List<int>();

            while (shouldIRide)
            {
                Console.Clear();
                Console.Write($"[{speed}][{actualDirection}] Go: ");
                var pressedKey = Console.ReadKey();

                if (pressedKey.Key == ConsoleKey.LeftArrow)
                {
                    if (actualDirection == DriveDirection.Front)
                    {
                        speed -= 1;
                        historyOfaRide.Add(speed);

                        if (speed == 0)
                            actualDirection = DriveDirection.None;
                    }

                    else if (actualDirection == DriveDirection.Back)
                    {
                        speed += 1;
                        historyOfaRide.Add(speed);
                    }

                    else
                    {
                        speed += 1;
                        historyOfaRide.Add(speed);
                        actualDirection = DriveDirection.Back;
                    }
                    continue;
                }
                if (pressedKey.Key == ConsoleKey.RightArrow)
                {
                    if (actualDirection == DriveDirection.Front)
                    {
                        speed += 1;
                        historyOfaRide.Add(speed);
                    }

                    else if (actualDirection == DriveDirection.Back)
                    {
                        speed -= 1;
                        historyOfaRide.Add(speed);

                        if (speed == 0)
                            actualDirection = DriveDirection.None;
                    }
                    else
                    {
                        speed += 1;
                        historyOfaRide.Add(speed);
                        actualDirection = DriveDirection.Front;
                    }

                    continue;
                }

                if (pressedKey.Key == ConsoleKey.Enter)
                {
                    Console.Write($"History of your ride: ");
                    foreach (var element in historyOfaRide)
                        Console.Write($"{element}km/h, ");
                    shouldIRide = false;
                }
            }
        }
        public void WriteWantedCarToRide()
        {
            var repository = new CarsRepository();
            var cars = repository.GetUnavailable();                       

            if (cars.Count == 0)
                Console.WriteLine("You did not rent a car");

            else
            {
                var component = new SelectCarComponent();
                var carWantedToBeRide = component.GetCarWithTemporaryId(cars, "ride");
                Render(carWantedToBeRide);                
            }

            Console.ReadKey();
        }
    }
}
