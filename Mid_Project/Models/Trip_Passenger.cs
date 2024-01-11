using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mid_Project.Models
{
    public class Trip_Passenger
    {
        [Key]
        public int ID { get; set; }


     
        [ForeignKey("TripID")]

        public Trip trip { get; set; }
        
        [ForeignKey("PassengerID")]

        public Passenger passenger { get; set; }
    }
}
