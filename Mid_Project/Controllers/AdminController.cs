using Microsoft.AspNetCore.Mvc;
using Mid_Project.Data;
using Mid_Project.Models;

namespace Mid_Project.Controllers
{
    public class AdminController : Controller
    {
        private SystemDbContext _context;

        public AdminController(SystemDbContext context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
            return View(_context.trip.ToList());
        }



        public ActionResult Details(int id)
        {
            Trip trip = _context.trip.Find(id);
            return View(trip);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Trip trip)
        {
            try
            {
                int adminid = (int)HttpContext.Session.GetInt32("adminID");

                Admin admin = _context.admin.Where(
                a => a.admin_Id == adminid
                ).FirstOrDefault();

                trip.Admin = admin;

                _context.trip.Add(trip);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Edit(int id)
        {
            Trip trip = _context.trip.Find(id);
            return View(trip);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Trip trip)
        {
            try
            {


                _context.trip.Update(trip);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));


            }
            catch
            {
                return View();
            }
        }


        public ActionResult Delete(int id)
        {
            Trip trip = _context.trip.Find(id);

            return View(trip);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Trip trip)
        {
            try
            {
                _context.trip.Remove(trip);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }






        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        
    }
}
