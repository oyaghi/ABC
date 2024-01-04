using System.ComponentModel.DataAnnotations.Schema;

namespace Mid_Project.Models
{
    public class Trip_Passenger
    {
        public int ID { get; set; }


        public int TripID { get; set; } // Foreign key
        public int PassengerID { get; set; } // Foreign key


        [ForeignKey("TripID")]

        public Trip trip { get; set; }
        
        [ForeignKey("PassengerID")]

        public Passenger passenger { get; set; }
    }
}
