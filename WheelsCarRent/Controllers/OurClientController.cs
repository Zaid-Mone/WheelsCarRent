using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WheelsCarRent.Data;
using WheelsCarRent.Models;

namespace WheelsCarRent.Controllers
{
    public class OurClientController : Controller
    {
        private readonly DataDbContext _context;

        public OurClientController(DataDbContext context)
        {
            _context = context;
        }

        // GET: OurClient
        public async Task<IActionResult> Index()
        {
            return View(await _context.OurClients.ToListAsync());
        }

        // GET: OurClient/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ourClient = await _context.OurClients
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ourClient == null)
            {
                return NotFound();
            }

            return View(ourClient);
        }

        // GET: OurClient/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OurClient/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Message")] OurClient ourClient)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ourClient);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index","Home");
            }
            return View(ourClient);
        }

        // GET: OurClient/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ourClient = await _context.OurClients.FindAsync(id);
            if (ourClient == null)
            {
                return NotFound();
            }
            return View(ourClient);
        }

        // POST: OurClient/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Message")] OurClient ourClient)
        {
            if (id != ourClient.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ourClient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OurClientExists(ourClient.Id))
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
            return View(ourClient);
        }

        // GET: OurClient/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ourClient = await _context.OurClients
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ourClient == null)
            {
                return NotFound();
            }

            return View(ourClient);
        }

        // POST: OurClient/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ourClient = await _context.OurClients.FindAsync(id);
            _context.OurClients.Remove(ourClient);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OurClientExists(int id)
        {
            return _context.OurClients.Any(e => e.Id == id);
        }
    }
}
