using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mid_Project.Data;
using Mid_Project.Models;

namespace Mid_Project.Controllers
{
    public class BusController : Controller
    {

        private SystemDbContext _context;

        public BusController(SystemDbContext context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {

            return View(_context.buss.ToList());
        }



        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.buss == null)
            {
                return NotFound();
            }

            var bus = _context.buss
                .FirstOrDefault(m => m.bus_Id == id);
            if (bus == null)
            {
                return NotFound();
            }

            return View(bus);
        }

        public IActionResult Create()
        {
            ViewBag.BusTrip = _context.trip.ToList();
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormCollection form)
        {
            int adminID = (int)HttpContext.Session.GetInt32("adminID");

            string CaptainName = form["captin_Name"];
            int Seats = int.Parse(form["number_of_seats"]);

            Buss bus = new Buss();
            bus.captin_Name = CaptainName;
            bus.number_of_seats = Seats;
            bus.admin = _context.admin.Find(adminID);

            _context.buss.Add(bus);
            _context.SaveChanges();

            return RedirectToAction("Index");

        }


        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.BusTrip = _context.trip.ToList();

            if (id == null || _context.buss == null)
            {
                return NotFound();
            }
            var players = await _context.buss.FindAsync(id);
            if (players == null)
            {
                return NotFound();
            }
            return View(players);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(IFormCollection form)
        {
            string CaptainName = form["captin_Name"];
            int Seats = int.Parse(form["number_of_seats"]);
            int id = int.Parse(form["bus_Id"]);

            Buss bus = _context.buss.Find(id);
            bus.captin_Name = CaptainName;
            bus.number_of_seats = Seats;

            


            _context.buss.Update(bus);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }



        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.buss == null)
            {
                return NotFound();
            }

            var bus = await _context.buss
                .FirstOrDefaultAsync(m => m.bus_Id == id);
            if (bus == null)
            {
                return NotFound();
            }

            return View(bus);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.buss == null)
            {
                return Problem("Entity set 'SystemDbContext.bus'  is null.");
            }
            var bus = await _context.buss.FindAsync(id);
            if (bus != null)
            {
                _context.buss.Remove(bus);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BusExists(int id)
        {
            return (_context.buss?.Any(e => e.bus_Id == id)).GetValueOrDefault();
        }
    }
}
