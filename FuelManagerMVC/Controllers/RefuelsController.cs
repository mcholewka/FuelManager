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
        public IActionResult AddRefuel()
        {
            return View();
        }
    }
}