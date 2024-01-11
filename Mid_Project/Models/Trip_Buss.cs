using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mid_Project.Models
{
    public class Trip_Buss
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("TripID")]
        public Trip trip { get; set; }

        [ForeignKey("BussID")]

        public Buss buss { get; set; }

    }
}
