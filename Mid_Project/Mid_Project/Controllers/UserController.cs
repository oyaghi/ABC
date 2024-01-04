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
                    return RedirectToAction("Team");
                }
                else if (admin != null)
                {

                    HttpContext.Session.SetInt32("adminID", admin.admin_Id);

                    return RedirectToAction("Index", "Teams");
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
    }
}
