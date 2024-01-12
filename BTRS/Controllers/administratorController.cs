using BTRS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace BTRS.Controllers
{
    public class administratorController : Controller
    {
        private MyDbContext _context;

        public administratorController(MyDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return _context.admins != null ?
                        View(await _context.admins.ToListAsync()) :
                        Problem("Entity set 'MyDbContext.admins'  is null.");
        }
        public IActionResult adminHome()
        {
            return View("adminHome");

        }

        [HttpPost]
        public IActionResult SelectMethod(methodSelection meth)
        {
            if (ModelState.IsValid)
            {
                if (meth.SelectedMethod == "SignUp")
                {

                    return RedirectToAction("SignUp", "administrator");
                }
                else if (meth.SelectedMethod == "Login")
                {

                    return RedirectToAction("Login", "administrator");
                }
            }


            return View("adminHome", meth);
        }
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(administrator admin)
        {
            _context.admins.Add(admin);
            _context.SaveChanges();
            ModelState.Clear();
            return RedirectToAction("SelectView","administrator");
        }
        public IActionResult SelectView(ViewSelection view)
        {
            if (ModelState.IsValid)
            {
                if (view.SelectedView == "Trips")
                {

                    return RedirectToAction("Index", "administratorTrips");
                }
                else if (view.SelectedView == "Bus")
                {

                    return RedirectToAction("Index", "administratorBuses");
                }
            }
            return View("SelectView", view);
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(administrator admin2)
        {
            if(_context.admins.Any(p => p.Username == admin2.Username && p.Password == admin2.Password))
            {
                return RedirectToAction("SelectView", "administrator");
            }
            else
            {
                TempData["Msg"] = "Invalid username or password";
            }
            return View(admin2);
        }
        public IActionResult Action()
        {
            return View();
        }

        

        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.admins == null)
            {
                return NotFound();
            }

            var administrator = await _context.admins
                .FirstOrDefaultAsync(m => m.AdminID == id);
            if (administrator == null)
            {
                return NotFound();
            }

            return View(administrator);
        }

        
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create (administrator admin2)
        {
            _context.admins.Add(admin2);
            _context.SaveChanges();
            ModelState.Clear();
            return RedirectToAction("Index", "administrator");
        }

        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.admins == null)
            {
                return NotFound();
            }

            var administrator = await _context.admins.FindAsync(id);
            if (administrator == null)
            {
                return NotFound();
            }
            return View(administrator);
        }
        
        [HttpPost]
        public IActionResult Edit(administrator admin2)
        {
            _context.admins.Update(admin2);
            _context.SaveChanges();
            return RedirectToAction("Index","administrator");
        }



        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.admins == null)
            {
                return NotFound();
            }

            var administrator = await _context.admins
                .FirstOrDefaultAsync(m => m.AdminID == id);
            if (administrator == null)
            {
                return NotFound();
            }

            return View(administrator);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.admins == null)
            {
                return Problem("Entity set 'MyDbContext.admins'  is null.");
            }
            var administrator = await _context.admins.FindAsync(id);
            if (administrator != null)
            {
                _context.admins.Remove(administrator);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool administratorExists(int id)
        {
            return (_context.admins?.Any(e => e.AdminID == id)).GetValueOrDefault();
        }
    }
}
