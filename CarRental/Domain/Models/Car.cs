
using CarRental.Domain.Models;
using System;
using System.Collections.Generic;

namespace CarRental
{
    public class Car
    {
        public Guid Id { get; private set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public int ProductionYear { get; set; }
        public int EnginePower { get; set; }        
        public virtual CarRental CarRental { get; set; }
        public int CarRentalId { get; set; }
        public Status Status { get; set; }
        public StatusOfRide StatusOfRide { get; set;}

        public Car(string brand, string color, int productionYear, int enginePower)
        { 
            Id = Guid.NewGuid();    
            Brand = brand;
            Color = color;
            ProductionYear = productionYear;
            EnginePower = enginePower;
            Status = Status.Available;
            StatusOfRide = StatusOfRide.Stop;
        }

        public Car()
        { }
    }
}
