using System.ComponentModel.DataAnnotations;

namespace Mid_Project.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Please fill the username")]
        public string username { set; get; }
        [Required(ErrorMessage = "Please fill the Password")]

        public string password { set; get; }
    }
}
