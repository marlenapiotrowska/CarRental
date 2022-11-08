using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity.ModelConfiguration;

namespace CarRental
{
    public class CarRentalConfiguration : EntityTypeConfiguration<CarRental>
    {
        public CarRentalConfiguration()
        {
            Property(r => r.Name)
                .IsRequired();

            HasMany(r => r.Cars)
                .WithRequired(c => c.CarRental);               

        }
        
    }
}
