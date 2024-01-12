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
    public class bookingTripsController : Controller
    {
        private readonly MyDbContext _context;

        public bookingTripsController(MyDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
              return _context.bookingtrips != null ? 
                          View(await _context.bookingtrips.ToListAsync()) :
                          Problem("Entity set 'MyDbContext.bookingtrips'  is null.");
        }

        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.bookingtrips == null)
            {
                return NotFound();
            }

            var bookingTrips = await _context.bookingtrips
                .FirstOrDefaultAsync(m => m.TripID == id);
            if (bookingTrips == null)
            {
                return NotFound();
            }

            return View(bookingTrips);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.bookingtrips == null)
            {
                return NotFound();
            }

            var trip = await _context.bookingtrips
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
            if (_context.bookingtrips == null)
            {
                return Problem("Entity set 'MyDbContext.trip'  is null.");
            }
            var trip = await _context.bookingtrips.FindAsync(id);
            if (trip != null)
            {
                _context.bookingtrips.Remove(trip);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Back()
        {
            return RedirectToAction("Index","passengerTrips");
        }

        private bool BookingTripsExists(int id)
        {
          return (_context.bookingtrips?.Any(e => e.TripID == id)).GetValueOrDefault();
        }
    }
}
