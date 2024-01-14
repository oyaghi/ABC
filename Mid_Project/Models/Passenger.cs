using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Mid_Project.Models
{ 

    [Index(nameof(Passenger.email), IsUnique = true)]
    [Index(nameof(Passenger.username), IsUnique = true)]




    public class Passenger
    {
        [Key]
        public int pass_Id { get; set; }
        [Required]
        public String name { get; set; }

        [Required]
        [EmailAddress]
        public String email { get; set; }
        [Required]
        public String gender { get; set; }
        [Required]
        public String username { get; set; }
        [Required]
        public int phone { get; set; }
        [Required]
        public String password { get; set; }


        // Many to Many with Trip (one to Many with Trip_Passenger)
        public ICollection<Trip_Passenger> trip_passenger { get; set; }




}
}
