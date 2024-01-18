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
    public class passengerTripsController : Controller
    {
        private readonly MyDbContext _context;

        public passengerTripsController(MyDbContext context)
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

        public IActionResult Book(int id)
        {
            
            var trip = _context.trip.Find(id);

            if (trip == null)
            {
                return NotFound();
            }

           
            var existingBooking = _context.bookingtrips
                .FirstOrDefault(bt => bt.TripID == id);

            if (existingBooking != null)
            {
                
                TempData["Message"] = "You have already booked this trip.";
                return RedirectToAction("Index", "passengerTrips");
            }

            
            var bookedTrip = new BookingTrips
            {
                TripID = id,
                Destination = trip.Destination,
                
            };

            
            _context.bookingtrips.Add(bookedTrip);
            _context.SaveChanges();

           
            return RedirectToAction("Index", "bookingTrips");
        }
        public IActionResult LogOut()
        {
            return RedirectToAction("passengerHome", "passenger");
        }
        public IActionResult View_Book()
        {
            return RedirectToAction("Index", "bookingTrips");
        }


    }
}
