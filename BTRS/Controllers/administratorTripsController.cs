using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BTRS.Models;

namespace BTRS.Controllers
{
    public class administratorTripsController : Controller
    {
        private readonly MyDbContext _context;

        public administratorTripsController(MyDbContext context)
        {
            _context = context;
        }

        
        public async Task<IActionResult> Index()
        {
              return _context.trip != null ? 
                          View(await _context.trip.ToListAsync()) :
                          Problem("Entity set 'MyDbContext.trip'  is null.");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.trip == null)
            {
                return NotFound();
            }

            var trip = await _context.trip
                .FirstOrDefaultAsync(m => m.TripID == id);
            if (trip == null)
            {
                return NotFound();
            }

            return View(trip);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(trip t1)
        {
            _context.trip.Add(t1);
            _context.SaveChanges();
            ModelState.Clear();
            return RedirectToAction("Index", "administratorTrips");
        }


        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.trip == null)
            {
                return NotFound();
            }

            var trip = await _context.trip.FindAsync(id);
            if (trip == null)
            {
                return NotFound();
            }
            return View(trip);
        }
        [HttpPost]
        public IActionResult Edit(trip t1)
        {
            _context.trip.Update(t1);
            _context.SaveChanges();
            return RedirectToAction("Index", "administratorTrips");
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.trip == null)
            {
                return NotFound();
            }

            var trip = await _context.trip
                .FirstOrDefaultAsync(m => m.TripID == id);
            if (trip == null)
            {
                return NotFound();
            }

            return View(trip);
        }

      
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.trip == null)
            {
                return Problem("Entity set 'MyDbContext.trip'  is null.");
            }
            var trip = await _context.trip.FindAsync(id);
            if (trip != null)
            {
                _context.trip.Remove(trip);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tripExists(int id)
        {
          return (_context.trip?.Any(e => e.TripID == id)).GetValueOrDefault();
        }
    }
}
