using System;
using CarRental.Domain.Models;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Text;
using CarRental.DataAccess;

namespace CarRental.Domain
{
    public class CarService
    {
        public void Rent(Car car)
        {
            if (car.Status == Status.Unavailable)
                throw new Exception("Car is already rented.");

            var status = Status.Unavailable;
            var repository = new CarsRepository();
            repository.UpdateStatus(car.Id, status);                        
        }
        public void Return(Car car)
        {
            var status = Status.Available;
            var repository = new CarsRepository();
            repository.UpdateStatus(car.Id, status);
        }
        public void Ride(Car car)
        {
            var status = StatusOfRide.Start;
            var repository = new CarsRepository();
            repository.UpdateStatusOfRide(car.Id, status);
        }
        public void StopRide(Car car)
        {
            var status = StatusOfRide.Stop;
            var repository = new CarsRepository();
            repository.UpdateStatusOfRide(car.Id, status);
        }
    }
}
