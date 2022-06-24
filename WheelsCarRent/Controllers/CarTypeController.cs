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
    public class CarTypeController : Controller
    {
        private readonly DataDbContext _context;
        private readonly IWebHostEnvironment _hosting;

        public CarTypeController(DataDbContext context, IWebHostEnvironment hosting)
        {
            _context = context;
            this._hosting = hosting;
        }

        // GET: CarType
        public async Task<IActionResult> Index()
        {
            return View(await _context.CarTypes.ToListAsync());
        }

        // GET: CarType/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carType = await _context.CarTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carType == null)
            {
                return NotFound();
            }

            return View(carType);
        }

        // GET: CarType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CarType/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CarTypeViewModel model)
        {
            if (ModelState.IsValid)
            {


                if (model.File != null)
                {
                    string uploads = Path.Combine(_hosting.WebRootPath, @"image\upload");
                    string fullPath = Path.Combine(uploads, model.File.FileName);

                    model.File.CopyTo(new FileStream(fullPath, FileMode.Create));
                }
                CarType carType = new CarType
                {
                    Id = model.CarTypeId,
                    Name = model.Name,
                    Image = model.File.FileName
                };
                _context.Add(carType);
                await _context.SaveChangesAsync();
                TempData["success"] = "Car Type Created Successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: CarType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carType = await _context.CarTypes.FindAsync(id);
            if (carType == null)
            {
                return NotFound();
            }
            CarTypeViewModel carTypeViewModel = new CarTypeViewModel
            {
                CarTypeId = carType.Id,
                Name = carType.Name,
                Image = carType.Image
            };
            return View(carTypeViewModel);
        }

        // POST: CarType/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CarTypeViewModel model)
        {
            if (id != model.CarTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (model.File != null)
                    {
                        string uploads = Path.Combine(_hosting.WebRootPath, @"image\upload");
                        string fullPath = Path.Combine(uploads, model.File.FileName);
                        model.File.CopyTo(new FileStream(fullPath, FileMode.Create));
                    }
                    CarType carType = new CarType
                    {
                        Id = model.CarTypeId,
                        Name = model.Name,
                        Image = model.File.FileName

                    };
                    _context.Update(carType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarTypeExists(model.CarTypeId))
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
            return View(model);
        }

        // GET: CarType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carType = await _context.CarTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carType == null)
            {
                return NotFound();
            }

            return View(carType);
        }

        // POST: CarType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carType = await _context.CarTypes.FindAsync(id);
            _context.CarTypes.Remove(carType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarTypeExists(int id)
        {
            return _context.CarTypes.Any(e => e.Id == id);
        }
    }
}
