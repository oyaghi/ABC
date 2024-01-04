using System.ComponentModel.DataAnnotations.Schema;

namespace Mid_Project.Models
{
    public class Trip_Buss
    {
        public int ID { get; set; }

        public int TripID { get; set; } // Foreign key
        public int BussID { get; set; } // Foreign key




        [ForeignKey("TripID")]
        public Trip trip { get; set; }

        [ForeignKey("BussID")]

        public Buss buss { get; set; }

    }
}
