using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Mid_Project.Models
{
    [Index(nameof(Admin.username), IsUnique = true)]

    public class Admin
    {
        [Key]
        public int admin_Id { get; set; }
        [Required]
        public String full_Name { get; set; }
        [Required]
        public String password { get; set; }
        [Required]
        public String username { get; set; }
        

        // One to Many with Trip
        public ICollection<Trip> trip { get; set; }

        // One to Many with Buss
        public ICollection<Buss> buss { get; set; }


    }
}
