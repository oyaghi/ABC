using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mid_Project.Data;
using Mid_Project.Models;

namespace Mid_Project.Controllers
{
    public class Trip_BussController : Controller
    {
        private readonly SystemDbContext _context;

        public Trip_BussController(SystemDbContext context)
        {
            _context = context;
        }

        // GET: Trip_Buss
        public  IActionResult Index()
        {
            return View(_context.trip_buss.Include(tb => tb.trip).Include(tb => tb.buss).ToList());
            
        }

        // GET: Trip_Buss/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            Trip_Buss tripBuss = _context.trip_buss
              .Include(tb => tb.trip) // Include the Trip navigation property
              .Include(tb => tb.buss) // Include the Buss navigation property
              .FirstOrDefault(tb => tb.ID == id);
            return View(tripBuss);
        }

        // GET: Trip_Buss/Create
        public IActionResult Create()
        {
            ViewBag.Buss = _context.buss.ToList();
            ViewBag.Trip = _context.trip.ToList();
            return View();
        }

        // POST: Trip_Buss/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public IActionResult Create(int trip, int bus)
        {
            Trip_Buss tp = new Trip_Buss();
            tp.trip = _context.trip.Find(trip);
            tp.buss = _context.buss.Find(bus);
            _context.trip_buss.Add(tp);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }


        // GET: Trip_Buss/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.Buss = _context.buss.ToList();
            ViewBag.Trip = _context.trip.ToList();
            return View();
        }

        // POST: Trip_Buss/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,int trip, int bus)
        {

            Trip_Buss tp = _context.trip_buss.Find(id);
            tp.trip = _context.trip.Find(trip);
            tp.buss = _context.buss.Find(bus);
            _context.trip_buss.Update(tp);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Trip_Buss/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
                Trip_Buss tripBuss = _context.trip_buss
                .Include(tb => tb.trip) // Include the Trip navigation property
                .Include(tb => tb.buss) // Include the Buss navigation property
                .FirstOrDefault(tb => tb.ID == id);
            return View(tripBuss);
        }

        // POST: Trip_Buss/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.trip_buss == null)
            {
                return Problem("Entity set 'SystemDbContext.trip_buss'  is null.");
            }
            var trip_Buss = await _context.trip_buss.FindAsync(id);
            if (trip_Buss != null)
            {
                _context.trip_buss.Remove(trip_Buss);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Trip_BussExists(int id)
        {
          return (_context.trip_buss?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
