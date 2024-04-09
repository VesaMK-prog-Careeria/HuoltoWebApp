using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HuoltoWebApp.Models;

namespace HuoltoWebApp.Controllers
{
    public class AutoController : Controller
    {
        private readonly HuoltoContext _context;

        public AutoController(HuoltoContext context)
        {
            _context = context;
        }

        // GET: Auto
        public async Task<IActionResult> Index()
        {
            var huoltoContext = _context.Autos.Include(a => a.Säiliö);
            return View(await huoltoContext.ToListAsync());
        }

        // GET: Auto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Autos == null)
            {
                return NotFound();
            }

            var auto = await _context.Autos
                .Include(a => a.Säiliö)
                .FirstOrDefaultAsync(m => m.AutoId == id);
            if (auto == null)
            {
                return NotFound();
            }

            return View(auto);
        }

        // GET: Auto/Create
        public IActionResult Create()
        {
            ViewData["SäiliöId"] = new SelectList(_context.Säiliös, "SäiliöId", "SäiliöId");
            return View();
        }

        // POST: Auto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AutoId,RekNro,SäiliöId,Katsastus,Adr,Piirturi,Alkolukko,Nopeudenrajoitin,AutoInfoId")] Auto auto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(auto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SäiliöId"] = new SelectList(_context.Säiliös, "SäiliöId", "SäiliöId", auto.SäiliöId);
            return View(auto);
        }

        // GET: Auto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Autos == null)
            {
                return NotFound();
            }

            var auto = await _context.Autos.FindAsync(id);
            if (auto == null)
            {
                return NotFound();
            }
            ViewData["SäiliöId"] = new SelectList(_context.Säiliös, "SäiliöId", "SäiliöId", auto.SäiliöId);
            return View(auto);
        }

        // POST: Auto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AutoId,RekNro,SäiliöId,Katsastus,Adr,Piirturi,Alkolukko,Nopeudenrajoitin,AutoInfoId")] Auto auto)
        {
            if (id != auto.AutoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(auto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutoExists(auto.AutoId))
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
            ViewData["SäiliöId"] = new SelectList(_context.Säiliös, "SäiliöId", "SäiliöId", auto.SäiliöId);
            return View(auto);
        }

        // GET: Auto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Autos == null)
            {
                return NotFound();
            }

            var auto = await _context.Autos
                .Include(a => a.Säiliö)
                .FirstOrDefaultAsync(m => m.AutoId == id);
            if (auto == null)
            {
                return NotFound();
            }

            return View(auto);
        }

        // POST: Auto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Autos == null)
            {
                return Problem("Entity set 'HuoltoContext.Autos'  is null.");
            }
            var auto = await _context.Autos.FindAsync(id);
            if (auto != null)
            {
                _context.Autos.Remove(auto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutoExists(int id)
        {
          return (_context.Autos?.Any(e => e.AutoId == id)).GetValueOrDefault();
        }
    }
}
