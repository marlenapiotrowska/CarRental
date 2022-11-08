using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;

namespace CarRental
{
    public class CarRentalContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarRental> CarRentals {get; set;}

        public CarRentalContext()
        {            
            Database.Connection.ConnectionString = "Server=.\\SQLEXPRESS;Database=CarRental;Trusted_Connection=True;";
        }
    }
}
