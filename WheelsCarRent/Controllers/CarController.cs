using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WheelsCarRent.Data;
using WheelsCarRent.Models;
using WheelsCarRent.ViewModels;

namespace WheelsCarRent.Controllers
{
    public class CarController : Controller
    {
        private readonly DataDbContext _context;
        private readonly IWebHostEnvironment _hosting;

        public CarController(DataDbContext context, IWebHostEnvironment hosting)
        {
            _context = context;
            this._hosting = hosting;
        }


        // GET: Car
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cars
                .Include(m=>m.CarType)
                .ToListAsync());
        }

        // GET: Car/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars
                .Include(m => m.CarType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // GET: Car/Create
        public IActionResult Create()
        {
            CarViewModel carViewModel = new CarViewModel
            {
                CarTypes = _context.CarTypes.ToList(),
            };
            return View(carViewModel);
        }

        // POST: Car/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CarViewModel models)
        {
            if (ModelState.IsValid)
            {
                if (models.File != null)
                {
                    string uploads = Path.Combine(_hosting.WebRootPath, @"image\upload");
                    //string extraPath = Guid.NewGuid().ToString();
                    string fullPath = Path.Combine(uploads, models.File.FileName);
                    models.File.CopyTo(new FileStream(fullPath, FileMode.Create));
                }

                Car car = new Car
                {
                    Id = models.CarId,
                    Name = models.Name,
                    PlateNumber = models.PlateNumber,
                    Price = models.Price,
                    Color = models.Color,
                    Description = models.Description,
                    Model = models.Model,
                    Year = models.Year,
                    DriverType = models.DriverType,
                    Image = models.File.FileName,
                    CarType = _context.CarTypes.Find(models.CarTypeId),
                };
                _context.Add(car);
                await _context.SaveChangesAsync();
                //TempData["success"] = "Car  Created Successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(models);
        }

        // GET: Car/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            CarViewModel carViewModel = new CarViewModel
            {
                CarId = car.Id,
                Name = car.Name,
                Color = car.Color,
                Year = car.Year,
                Model = car.Model,
                Description = car.Description,
                DriverType = car.DriverType,
                Image = car.Image,
                Price = car.Price,
                PlateNumber = car.PlateNumber,
                CarTypes = _context.CarTypes.ToList(),
                CarTypeId = car.CarType.Id,
            };
            return View(carViewModel);
        }

        // POST: Car/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CarViewModel models)
        {
            if (id != models.CarId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (models.File != null)
                    {
                        string uploads = Path.Combine(_hosting.WebRootPath, @"image\upload");
                        string fullPath = Path.Combine(uploads, models.File.FileName);
                        models.File.CopyTo(new FileStream(fullPath, FileMode.Create));
                    }
                    Car car = new Car
                    {
                        Id = models.CarId,
                        Color = models.Color,
                        Description = models.Description,
                        Model = models.Model,
                        Year = models.Year,
                        Image = models.File.FileName,
                        DriverType = models.DriverType,
                        PlateNumber = models.PlateNumber,
                        Price = models.Price,
                        Name = models.Name,
                        CarType = _context.CarTypes.Find(models.CarTypeId),
                    };

                    _context.Update(car);
                    await _context.SaveChangesAsync();
                    //TempData["success"] = "Car  Updated Successfully";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(models.CarId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            return View(models);
        }

        // GET: Car/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars
                .Include(m => m.CarType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // POST: Car/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarExists(int id)
        {
            return _context.Cars.Any(e => e.Id == id);
        }
    }
}
