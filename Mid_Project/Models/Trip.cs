using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mid_Project.Models
{
    public class Trip
    {
        [Key]
        public int trip_Id { get; set; }
        public string destination { get; set; }
        public DateTime start_Date { get; set; }
        public DateTime end_Date { get; set; }
        public int bus_Number { get; set; }

        // Many to one with Admin
        [ForeignKey("AdminID")]
        public Admin Admin { get; set; }

        // Many to Many with passenger
        public ICollection<Passenger> passenger {  get; set; }

        // Many to Many with Buss
        public ICollection<Buss> buss {  get; set; }


    }
}
