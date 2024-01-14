using Microsoft.AspNetCore.Mvc;
using Mid_Project.Data;
using Mid_Project.Models;

namespace Mid_Project.Controllers
{
    public class UserController : Controller
    {

        private SystemDbContext _context;

        public UserController(SystemDbContext context)
        {
            this._context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login login)
        {

            if (ModelState.IsValid)
            {
                string username = login.username;
                string password = login.password;

                Passenger passenger = _context.passenger.Where(
                     u => u.username.Equals(username) &&
                     u.password.Equals(password)
                     ).FirstOrDefault();

                Admin admin = _context.admin.Where(
                    a => a.username.Equals(username)
                    &&
                    a.password.Equals(password)
                    ).FirstOrDefault();




                if (passenger != null)
                {
                    HttpContext.Session.SetInt32("PassengerId", passenger.pass_Id);

                    return RedirectToAction("BookingList","Passenger");
                }
                else if (admin != null)
                {

                    HttpContext.Session.SetInt32("adminID", admin.admin_Id);

                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    TempData["Msg"] = "The user Not Found";
                }


            }
            else
            {

            }
            return View();
        }



        // new Mustafa Functions ---------------------------------------------------------------------------------------------------------

        public bool CheckEmpty(Passenger passenger)
        {
            if (String.IsNullOrEmpty(passenger.name)) return false;
            else if (string.IsNullOrEmpty(passenger.password)) return false;
            else if (string.IsNullOrEmpty(passenger.username)) return false;
            else if (string.IsNullOrEmpty(passenger.gender)) return false;
            else if (string.IsNullOrEmpty(passenger.phone.ToString())) return false;
            else if (string.IsNullOrEmpty(passenger.email)) return false;
            else return true;

        }

        [HttpGet]
        public IActionResult SignUp()
        {

            return View();
        }

        [HttpPost]
        public IActionResult SignUp(Passenger passenger)
        {
            bool empty = CheckEmpty(passenger);


            if (empty)
            {
                try {
                    _context.passenger.Add(passenger);
                    _context.SaveChanges();
                    TempData["Msg"] = "the data was saved";

                    return RedirectToAction("Login");
                }
                catch
                {
                    TempData["Msg"] = "The Username already exists";
                    return View();
                }
                

            }
            else
            {
                TempData["Msg"] = "Fill all the fields";
            }

            return View();

        }
    }
}
