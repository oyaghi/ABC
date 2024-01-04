﻿using System.ComponentModel.DataAnnotations;

namespace Mid_Project.Models
{
    public class Passenger
    {
        [Key]
        public int pass_Id { get; set; }
        public String name { get; set; }
        [Required]
        public String email { get; set; }
        [Required]
        public String gender { get; set; }
        [Required]
        public String username { get; set; }
        public int phone { get; set; }
        [Required]
        public String password { get; set; }


        // Many to Many with Trip (one to Many with Trip_Passenger)
        public ICollection<Trip_Passenger> trip_passenger { get; set; }

    }
}
