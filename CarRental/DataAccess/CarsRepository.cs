using CarRental.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace CarRental.DataAccess
{
    public class CarsRepository
    {
        private const string _path = @"D:\4 - Maja sie uczy\4 - My apps\CarRentalFiles";

        private string ReadLinesInText(string filePath, int lineToSkip, int lineToTake)
        {
            var text = File.ReadLines(filePath).Skip(lineToSkip).Take(lineToTake).First();

            return text;
        }

        private T GetValue<T>(string filePath, int lineToSkip, int lineToTake)
        {
            var value = ReadLinesInText(filePath, lineToSkip, lineToTake);

            return (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFromInvariantString(value);
        }

        public List<Car> GetAllCars()
        {
            var listOfAllCars = new List<Car>();
            var files = Directory.GetFiles(_path);

            foreach (var file in files)
            {
                var carId = GetValue<Guid>(file, 0, 1);
                var carBrand = GetValue<string>(file, 1, 1);
                var carColor = GetValue<string>(file, 2, 1);
                var carProductionYear = GetValue<int>(file, 3, 1);
                var carEnginePower = GetValue<int>(file, 4, 1);
                var status = GetValue<Status>(file, 5, 1);
                var statusOfRide = GetValue<StatusOfRide>(file, 6, 1);

                var car = new Car(carBrand, carColor, carProductionYear, carEnginePower);
                listOfAllCars.Add(car);
                
                car.Id = carId;
                car.Status = status;
                car.StatusOfRide = statusOfRide;
            }

            return listOfAllCars;
        }

        public List<Car> GetAvailable()
        {
            var getCars = GetAllCars();
            var listOfAvailableCars = getCars
                .Where(c => c.Status == Status.Available)
                .ToList();

            return listOfAvailableCars;
        }

        public List<Car> GetUnavailable()
        {
            var getCars = GetAllCars();
            var listOfUnavailableCars = getCars
                .Where(c => c.Status == Status.Unavailable)
                .ToList();

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

            File.WriteAllLines($@"{_path}\{car.Id}.txt", carProperties);
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
                $@"{_path}\{carToChangeStatus.Id}.txt",
                6);

            return carToChangeStatus;
        }

        public Car UpdateStatusOfRide(Guid id, StatusOfRide status)
        {
            var getCars = GetAllCars();
            var carToChangeStatus = getCars.Find(c => c.Id == id);
            carToChangeStatus.StatusOfRide = status;

            ChangeStatusInFile(status.ToString(),
                $@"{_path}\{carToChangeStatus.Id}.txt",
                7);

            return carToChangeStatus;
        }

    }
}
