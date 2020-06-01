using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FuelManagerMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FuelManagerMVC.Controllers
{
    public class StatsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public StatsController(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index(int month = 1)
        {
            var query = await _db.Refuels.Where(x => x.RefuelDate.Month == month).ToListAsync();
            decimal allAmount = 0;
            decimal allPrice = 0;

            foreach(var item in query)
            {
                allAmount += item.Amount;
                allPrice += item.Price;
            }
            ViewData["allAmount"] = allAmount;
            ViewData["allPrice"] = allPrice;
            return View(query);
        }
        [HttpPost]
        public async Task<IActionResult> Index(string valueINeed)
        {
            var query = await _db.Refuels.Where(x => x.RefuelDate.Month == Int32.Parse(valueINeed)).ToListAsync();
            decimal allAmount = 0;
            decimal allPrice = 0;

            foreach (var item in query)
            {
                allAmount += item.Amount;
                allPrice += item.Price;
            }
            ViewData["allAmount"] = allAmount;
            ViewData["allPrice"] = allPrice;
            return View(query);
        }
    }
}