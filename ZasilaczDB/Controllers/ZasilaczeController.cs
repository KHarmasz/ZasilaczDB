using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ZasilaczDB.Models;
using Zasilacze;

namespace ZasilaczDB.Controllers
{
    public class ZasilaczeController : Controller
    {
        private readonly Baza _context;

        public ZasilaczeController(Baza context)
        {
            _context = context;
        }

        // GET: Zasilacze
        public async Task<IActionResult> Index()
        {
              return View(await _context.Zasilacz.ToListAsync());
        }

        // GET: Zasilacze/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Zasilacz == null)
            {
                return NotFound();
            }

            var zasilacz = await _context.Zasilacz
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zasilacz == null)
            {
                return NotFound();
            }

            return View(zasilacz);
        }

        // GET: Zasilacze/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zasilacze/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Marka,Model,Moc,Certyfikat,Cena")] Zasilacz zasilacz)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zasilacz);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zasilacz);
        }

        // GET: Zasilacze/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Zasilacz == null)
            {
                return NotFound();
            }

            var zasilacz = await _context.Zasilacz.FindAsync(id);
            if (zasilacz == null)
            {
                return NotFound();
            }
            return View(zasilacz);
        }

        // POST: Zasilacze/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Marka,Model,Moc,Certyfikat,Cena")] Zasilacz zasilacz)
        {
            if (id != zasilacz.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zasilacz);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZasilaczExists(zasilacz.Id))
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
            return View(zasilacz);
        }

        // GET: Zasilacze/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Zasilacz == null)
            {
                return NotFound();
            }

            var zasilacz = await _context.Zasilacz
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zasilacz == null)
            {
                return NotFound();
            }

            return View(zasilacz);
        }

        // POST: Zasilacze/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Zasilacz == null)
            {
                return Problem("Entity set 'Baza.Zasilacz'  is null.");
            }
            var zasilacz = await _context.Zasilacz.FindAsync(id);
            if (zasilacz != null)
            {
                _context.Zasilacz.Remove(zasilacz);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZasilaczExists(int id)
        {
          return _context.Zasilacz.Any(e => e.Id == id);
        }
    }
}
