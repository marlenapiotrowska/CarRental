using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarRental
{
    public class CarRental
    {       
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Car> Cars { get; set; }
    }

}




