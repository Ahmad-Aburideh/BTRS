using BTRS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BTRS.Controllers
{
    public class passengerController : Controller
    {
        private MyDbContext _context;

        public passengerController(MyDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return _context.passengers != null ?
                        View(await _context.passengers.ToListAsync()) :
                        Problem("Entity set 'MyDbContext.admins'  is null.");
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.passengers == null)
            {
                return NotFound();
            }

            var passenger = await _context.passengers
                .FirstOrDefaultAsync(m => m.PassengerID == id);
            if (passenger == null)
            {
                return NotFound();
            }

            return View(passenger);
        }
        public IActionResult passengerHome()
        {
            return View("passengerHome");
        }
        [HttpPost]
        public IActionResult SelectMethod(methodSelection meth)
        {
            if (ModelState.IsValid)
            {
                if (meth.SelectedMethod == "SignUp")
                {
                    
                    return RedirectToAction("SignUp", "passenger");
                }
                else if (meth.SelectedMethod == "Login")
                {
                    
                    return RedirectToAction("Login", "passenger");
                }
            }

            
            return View("passengerHome", meth);
        }

        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(passenger passenger)
        {
            List<string> errorMessages = new List<string>();

            if (_context.passengers.Any(p => p.Username == passenger.Username))
            {
                errorMessages.Add("Username already in use, Please choose a different one.\n");
            }

            if (_context.passengers.Any(p => p.EmailAddress == passenger.EmailAddress))
            {
                errorMessages.Add("Email address already in use,Please use a different one.\n");
            }

            if (_context.passengers.Any(p => p.PhoneNumber == passenger.PhoneNumber))
            {
                errorMessages.Add("Phone number already in use,Please use a different one.\n");
            }

            if (errorMessages.Any())
            {
                TempData["Msg"] = string.Join("\n", errorMessages);
                return View(passenger);
            }
            var allBookingTrips = _context.bookingtrips.ToList();
            _context.bookingtrips.RemoveRange(allBookingTrips);
            _context.SaveChanges();


            _context.passengers.Add(passenger);
            _context.SaveChanges();

            return RedirectToAction("Index", "passengerTrips");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(passenger data)
        {


            if (_context.passengers.Any(p => p.Username == data.Username && p.Password == data.Password))
            {
                return RedirectToAction("Index", "passengerTrips");
            }
            else
            {
                TempData["Msg"] = "There Are No Account Registered With This Username And Password,Please SignUp first!";
            }
            


            return View(data);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.passengers == null)
            {
                return NotFound();
            }

            var passenger = await _context.passengers
                .FirstOrDefaultAsync(m => m.PassengerID == id);
            if (passenger == null)
            {
                return NotFound();
            }

            return View(passenger);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.passengers == null)
            {
                return Problem("Entity set 'MyDbContext.admins'  is null.");
            }
            var passenger = await _context.passengers.FindAsync(id);
            if (passenger != null)
            {
                _context.passengers.Remove(passenger);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



    }
}
