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
    public class SäiliöController : Controller
    {
        private readonly HuoltoContext _context;

        public SäiliöController(HuoltoContext context)
        {
            _context = context;
        }

        // GET: Säiliö
        public async Task<IActionResult> Index()
        {
              return _context.Säiliös != null ? 
                          View(await _context.Säiliös.ToListAsync()) :
                          Problem("Entity set 'HuoltoContext.Säiliös'  is null.");
        }

        // GET: Säiliö/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Säiliös == null)
            {
                return NotFound();
            }

            var säiliö = await _context.Säiliös
                .FirstOrDefaultAsync(m => m.SäiliöId == id);
            if (säiliö == null)
            {
                return NotFound();
            }

            return View(säiliö);
        }

        // GET: Säiliö/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Säiliö/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SäiliöId,SäiliöNro,Vakaus,Välitarkastus,Määräaikaistarkastus,SäiliöInfoId")] Säiliö säiliö)
        {
            if (ModelState.IsValid)
            {
                _context.Add(säiliö);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(säiliö);
        }

        // GET: Säiliö/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Säiliös == null)
            {
                return NotFound();
            }

            var säiliö = await _context.Säiliös.FindAsync(id);
            if (säiliö == null)
            {
                return NotFound();
            }
            return View(säiliö);
        }

        // POST: Säiliö/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SäiliöId,SäiliöNro,Vakaus,Välitarkastus,Määräaikaistarkastus,SäiliöInfoId")] Säiliö säiliö)
        {
            if (id != säiliö.SäiliöId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(säiliö);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SäiliöExists(säiliö.SäiliöId))
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
            return View(säiliö);
        }

        // GET: Säiliö/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Säiliös == null)
            {
                return NotFound();
            }

            var säiliö = await _context.Säiliös
                .FirstOrDefaultAsync(m => m.SäiliöId == id);
            if (säiliö == null)
            {
                return NotFound();
            }

            return View(säiliö);
        }

        // POST: Säiliö/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Säiliös == null)
            {
                return Problem("Entity set 'HuoltoContext.Säiliös'  is null.");
            }
            var säiliö = await _context.Säiliös.FindAsync(id);
            if (säiliö != null)
            {
                _context.Säiliös.Remove(säiliö);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SäiliöExists(int id)
        {
          return (_context.Säiliös?.Any(e => e.SäiliöId == id)).GetValueOrDefault();
        }
    }
}
