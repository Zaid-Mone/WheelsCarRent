using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WheelsCarRent.Data;
using WheelsCarRent.Models;
using WheelsCarRent.ViewModels;

namespace WheelsCarRent.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataDbContext _db;

        public HomeController(ILogger<HomeController> logger, DataDbContext db)
        {
            _logger = logger;
            this._db = db;
        }

        public IActionResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel
            {
                Cars = _db.Cars.ToList(),
                CarTypes=_db.CarTypes.ToList(),
                OurClients = _db.OurClients.ToList()
            };
            return View(homeViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
