using CarRental.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.IO;

namespace CarRental.DataAccess
{
    public class CarsRepository
    {
        public List<Car> GetAllCars()
        {
            var listOfAllCars = new List<Car>();
            var files = Directory.GetFiles(@"D:\4 - Maja sie uczy\4 - My apps\CarRentalFiles");
           
            foreach (var file in files)
            {
                var text = File.ReadLines(file);
                var carId = Guid.Parse(text.Take(1).First());
                var carBrand = text.Skip(1).Take(1).First().ToString();
                var carColor = text.Skip(2).Take(1).First().ToString();
                var carProductionYear = int.Parse(text.Skip(3).Take(1).First());
                var carEnginePower = int.Parse(text.Skip(4).Take(1).First());
                var status = text.Skip(5).Take(1).First().ToString();
                var statusOfRide = text.Skip(6).Take(1).First();
                var car = new Car(carBrand, carColor, carProductionYear, carEnginePower);
                listOfAllCars.Add(car);

                car.Id = carId;
                if(statusOfRide == "Start")
                    car.StatusOfRide = StatusOfRide.Start;
                else 
                    car.StatusOfRide = StatusOfRide.Stop;

                if (status == "Available")
                    car.Status = Status.Available;
                else
                    car.Status = Status.Unavailable;
                }

            return listOfAllCars;
        }

        public List<Car> GetAvailable()
        {
            var getCars = GetAllCars();
            var listOfAvailableCars = getCars.Where(c => c.Status == Status.Available).ToList();

            return listOfAvailableCars;
        }

        public List<Car> GetUnavailable()
        {
            var getCars = GetAllCars();
            var listOfUnavailableCars = getCars.Where(c => c.Status == Status.Unavailable).ToList();

            return listOfUnavailableCars;
        }

        public void Add(Car car)
        {
            string[] carProperties = {
                car.Id.ToString(),
                car.Brand,
                car.Color,
                car.ProductionYear.ToString(),
                car.EnginePower.ToString(),
                car.Status.ToString(),
                car.StatusOfRide.ToString()};

            File.WriteAllLines($@"D:\4 - Maja sie uczy\4 - My apps\CarRentalFiles\{car.Id}.txt", carProperties);
        }

        public void ChangeStatusInFile(string status, string filePath, int lineToEdit)
        {
            string[] arrLine = File.ReadAllLines(filePath);
            arrLine[lineToEdit - 1] = status;
            File.WriteAllLines(filePath, arrLine);
        }

        public Car UpdateStatus(Guid id, Status status)
        {
            var getCars = GetAllCars();
            var carToChangeStatus = getCars.Find(c => c.Id == id);
            carToChangeStatus.Status = status;

            ChangeStatusInFile(status.ToString(), 
                $@"D:\4 - Maja sie uczy\4 - My apps\CarRentalFiles\{carToChangeStatus.Id}.txt", 
                6);            

            return carToChangeStatus;
        }

        public Car UpdateStatusOfRide(Guid id, StatusOfRide status)
        {
            var getCars = GetAllCars();
            var carToChangeStatus = getCars.Find(c => c.Id == id);
            carToChangeStatus.StatusOfRide = status;

            ChangeStatusInFile(status.ToString(),
                $@"D:\4 - Maja sie uczy\4 - My apps\CarRentalFiles\{carToChangeStatus.Id}.txt",
                7);

            return carToChangeStatus;
        }

    }
}
