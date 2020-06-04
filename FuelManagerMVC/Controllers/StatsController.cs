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
            var avarage = (allPrice / allAmount);
            ViewData["allAmount"] = allAmount;
            ViewData["allPrice"] = allPrice;
            ViewData["avarage"] = avarage;
            return View(query);
        }
        [HttpPost]
        public async Task<IActionResult> Index(DateTime startDate, DateTime endDate)
        {
   
            if(DateTime.Compare(startDate, endDate)>0)
            {
                ModelState.AddModelError("RefuelDate", "Wrong date format.");
                return View();
            }
            else
            {
                var query = await _db.Refuels.Where(x => x.RefuelDate > startDate && x.RefuelDate < endDate).ToListAsync();
                decimal allAmount = 0;
                decimal allPrice = 0;
                if(query.Count!=0)
                {
                    foreach (var item in query)
                    {
                        allAmount += item.Amount;
                        allPrice += item.Price;
                    }
                    var avarage = (allPrice / allAmount);
                    ViewData["allAmount"] = allAmount;
                    ViewData["allPrice"] = allPrice;
                    ViewData["avarage"] = avarage;

                    return View(query);
                }
                else
                {
                    ModelState.AddModelError("Empty", "No refuels in this time");

                    return View();
                }
            }
            
        }
    }
}