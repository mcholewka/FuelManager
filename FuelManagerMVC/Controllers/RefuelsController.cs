using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FuelManagerMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FuelManagerMVC.Controllers
{
    public class RefuelsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public RefuelsController(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            ViewData["Message"] = "Hello mordo";
            var list = await _db.Refuels.ToListAsync();
            return View(list);
        }

        public IActionResult AddRefuel(int id = 0)
        {
            if (id == 0)
                return View(new Refuel());
            else
                return View(_db.Refuels.Find(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddRefuel([Bind("Id,Station,Amount,Price, RefuelDate")] Refuel refuel)
        {
            if (ModelState.IsValid)
            {
                if (refuel.Id == 0)
                    _db.Add(refuel);
                else
                    _db.Update(refuel);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(refuel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var refuel = await _db.Refuels.FindAsync(id);
            _db.Refuels.Remove(refuel);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}