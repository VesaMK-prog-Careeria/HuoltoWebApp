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
    public class PvController : Controller
    {
        private readonly HuoltoContext _context;

        public PvController(HuoltoContext context)
        {
            _context = context;
        }

        // GET: Pv
        public async Task<IActionResult> Index()
        {
              return _context.Pvs != null ? 
                          View(await _context.Pvs.ToListAsync()) :
                          Problem("Entity set 'HuoltoContext.Pvs'  is null.");
        }

        // GET: Pv/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pvs == null)
            {
                return NotFound();
            }

            var pv = await _context.Pvs
                .FirstOrDefaultAsync(m => m.PvId == id);
            if (pv == null)
            {
                return NotFound();
            }

            return View(pv);
        }

        // GET: Pv/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pv/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PvId,RekNro,Katsastus,Adr,Välitarkastus,Määräaikaistarkastus,PvInfoId")] Pv pv)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pv);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pv);
        }

        // GET: Pv/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pvs == null)
            {
                return NotFound();
            }

            var pv = await _context.Pvs.FindAsync(id);
            if (pv == null)
            {
                return NotFound();
            }
            return View(pv);
        }

        // POST: Pv/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PvId,RekNro,Katsastus,Adr,Välitarkastus,Määräaikaistarkastus,PvInfoId")] Pv pv)
        {
            if (id != pv.PvId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pv);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PvExists(pv.PvId))
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
            return View(pv);
        }

        // GET: Pv/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pvs == null)
            {
                return NotFound();
            }

            var pv = await _context.Pvs
                .FirstOrDefaultAsync(m => m.PvId == id);
            if (pv == null)
            {
                return NotFound();
            }

            return View(pv);
        }

        // POST: Pv/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pvs == null)
            {
                return Problem("Entity set 'HuoltoContext.Pvs'  is null.");
            }
            var pv = await _context.Pvs.FindAsync(id);
            if (pv != null)
            {
                _context.Pvs.Remove(pv);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PvExists(int id)
        {
          return (_context.Pvs?.Any(e => e.PvId == id)).GetValueOrDefault();
        }
    }
}
