using System.Data.Entity.ModelConfiguration;


namespace CarRental
{
    public class CarConfiguration : EntityTypeConfiguration<Car>
    {
        public CarConfiguration()
        {
            Property(c => c.Brand)
                .IsRequired();

            Property(c => c.Color)
                .IsRequired();

            HasRequired(c => c.CarRental)
                .WithMany(r => r.Cars)
                .HasForeignKey(c => c.CarRentalId);
        }
    }
}
