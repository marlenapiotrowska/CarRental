﻿using System.Data.Entity;

namespace CarRental.DataAccess
{
    public class CarRentalContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarRental> CarRentals { get; set; }

        public CarRentalContext()
        {
            Database.Connection.ConnectionString = "Server=.\\SQLEXPRESS;Database=CarRental;Trusted_Connection=True;";
        }
    }
}
