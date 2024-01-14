using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mid_Project.Data;
using Mid_Project.Models;

namespace Mid_Project.Controllers
{
    public class PassengerController : Controller
    {
        private SystemDbContext _context;

        public PassengerController(SystemDbContext context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult BookingList()
        {
            int passengerId = (int)HttpContext.Session.GetInt32("PassengerId");

            List<Trip_Passenger> trip_passenger = _context.trip_passenger
                .Include(tp => tp.trip)
                .Where(tp => tp.passenger.pass_Id == passengerId)
                .ToList();

            List<Trip_Buss> allBussTrips = new List<Trip_Buss>(); // Collection to store all Buss_trip objects

            foreach (var trip in trip_passenger)
            {
                int tripId = trip.trip.trip_Id;

                List<Trip_Buss> buss_trip = _context.trip_buss
                    .Where(bt => bt.trip.trip_Id == tripId)
                    .ToList();

                allBussTrips.AddRange(buss_trip); // Add fetched Buss_trip objects to the collection
            }

            return View(allBussTrips); // Return the collection containing all Buss_trip objects
        }


        [HttpGet]
        public IActionResult Book()
        {
            List<Trip_Buss> trips = _context.trip_buss
                .Include(tb => tb.trip) // Include the related Trip
                .Include(tb => tb.buss) // Include the related Buss
                .ToList();

            return View(trips);
        }


        [HttpPost]
        public IActionResult Book(int id)
        {
            Trip_Passenger tp = new Trip_Passenger();
            int passengerId = (int)HttpContext.Session.GetInt32("PassengerId");
            tp.passenger = _context.passenger.Find(passengerId);
            tp.trip = _context.trip.Find(id);

             var existingEntry = _context.trip_passenger
                    .FirstOrDefault(tp => tp.trip.trip_Id == id && tp.passenger.pass_Id == passengerId);

            if (existingEntry != null)
            {
                return RedirectToAction("BookingList");

            }


            _context.trip_passenger.Add(tp);
            _context.SaveChanges();

            return RedirectToAction("BookingList");
        }

     

        [HttpPost]
        public IActionResult Delete(int id)
        {
            int passengerId = (int)HttpContext.Session.GetInt32("PassengerId");

            Trip_Passenger book = _context.trip_passenger.Where(tp => tp.trip.trip_Id == id && tp.passenger.pass_Id == passengerId).FirstOrDefault();
            if (book != null)
            {
                _context.trip_passenger.Remove(book);
                _context.SaveChanges();
            }
            return RedirectToAction("BookingList");
        }



        // new Mustafa Functions ---------------------------------------------------------------------------------------------------------

    }
}
