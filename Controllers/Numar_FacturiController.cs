using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Economat_v2.Data;
using Economat_v2.Models;

namespace Economat_v2.Controllers
{
    public class Numar_FacturiController : Controller
    {
        private readonly EconomatContext _context;

        public Numar_FacturiController(EconomatContext context)
        {
            _context = context;
        }

        // GET: Numar_Facturi
        public async Task<IActionResult> Index()
        {
            return View(await _context.Numar_Facturi.ToListAsync());
        }

        // GET: Numar_Facturi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var numar_Factura = await _context.Numar_Facturi
                .FirstOrDefaultAsync(m => m.Id == id);
            if (numar_Factura == null)
            {
                return NotFound();
            }

            return View(numar_Factura);
        }

        // GET: Numar_Facturi/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Numar_Facturi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Serie,Numar_Inceput,Numar_Sfarsit,Data,Numar_Curent")] Numar_Factura numar_Factura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(numar_Factura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(numar_Factura);
        }

        // GET: Numar_Facturi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var numar_Factura = await _context.Numar_Facturi.FindAsync(id);
            if (numar_Factura == null)
            {
                return NotFound();
            }
            return View(numar_Factura);
        }

        // POST: Numar_Facturi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Serie,Numar_Inceput,Numar_Sfarsit,Data,Numar_Curent")] Numar_Factura numar_Factura)
        {
            if (id != numar_Factura.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(numar_Factura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Numar_FacturaExists(numar_Factura.Id))
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
            return View(numar_Factura);
        }

        // GET: Numar_Facturi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var numar_Factura = await _context.Numar_Facturi
                .FirstOrDefaultAsync(m => m.Id == id);
            if (numar_Factura == null)
            {
                return NotFound();
            }

            return View(numar_Factura);
        }

        // POST: Numar_Facturi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var numar_Factura = await _context.Numar_Facturi.FindAsync(id);
            _context.Numar_Facturi.Remove(numar_Factura);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Numar_FacturaExists(int id)
        {
            return _context.Numar_Facturi.Any(e => e.Id == id);
        }
    }
}
