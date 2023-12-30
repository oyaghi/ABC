﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mid_Project.Models
{
    public class Buss
    {
        [Key]
        public int bus_Id { get; set; }
        [Required]
        public String captin_Name { get; set; }
        [Required]
        public int number_of_seats { get; set; }

        // Many to Many with Trip
        public ICollection<Trip> trip {  get; set; }

        // Many to one with Admin
        [ForeignKey("AdminID")]
        public Admin admin { get; set; }
    }
}
