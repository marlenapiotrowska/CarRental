using CarRental.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;

namespace CarRental.DataAccess
{
    public class CarsRepository
    {
        public List<Car> GetAvailable()
        {
            var context = new CarRentalContext();
            var listOfCars = context.Cars
                .Where(c => c.Status == Status.Available)
                .ToList();
            return listOfCars;
        }
        public List<Car> GetUnavailable()
        {
            var context = new CarRentalContext();
            var listOfCars = context.Cars
                .Where(c => c.Status == Status.Unavailable)
                .ToList();
            return listOfCars;
        }

        public Car Add(Car car)
        {
            var context = new CarRentalContext();
            var addedCar = context.Cars.Add(car);
            context.SaveChanges();

            return addedCar;
        }

        public Car UpdateStatus(Guid id, Status status)
        {
            var context = new CarRentalContext();
            var carToChangeStatus = context.Cars.Find(id);
            carToChangeStatus.Status = status;

            context.SaveChanges();

            return carToChangeStatus;
        }

        public Car UpdateStatusOfRide(Guid id, StatusOfRide status)
        {
            var context = new CarRentalContext();
            var carToChangeStatus = context.Cars.Find(id);
            carToChangeStatus.StatusOfRide = status;

            context.SaveChanges();

            return carToChangeStatus;
        }

    }
}
