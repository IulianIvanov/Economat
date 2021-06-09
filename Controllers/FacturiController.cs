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
    public class FacturiController : Controller
    {
        private readonly EconomatContext _context;

        public FacturiController(EconomatContext context)
        {
            _context = context;
        }

        // GET: Facturi
        public async Task<IActionResult> Index()
        {
            var economatContext = _context.Facturi.Include(f => f.Angajat).Include(f => f.Companie).Include(f => f.Numar_Factura);
            return View(await economatContext.ToListAsync());
        }

        // GET: Facturi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factura = await _context.Facturi
                .Include(f => f.Angajat)
                .Include(f => f.Companie)
                .Include(f => f.Numar_Factura)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (factura == null)
            {
                return NotFound();
            }

            return View(factura);
        }

        // GET: Facturi/Create
        public IActionResult Create()
        {
            ViewData["AngajatId"] = new SelectList(_context.Angajati, "Id", "Nume_Prenume");
            ViewData["CompanieId"] = new SelectList(_context.Companii, "Id", "Nume");
            ViewData["Numar_FacturaId"] = new SelectList(_context.Numar_Facturi, "Id", "Id");
            return View();
        }

        // POST: Facturi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CIM_Angajat,Nume_Angajat,Data,Serie,Numar_Document,Tip_Document,Suma_Totala,Suma_Platita,Restanta,AngajatId,CompanieId,Numar_FacturaId")] Factura factura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(factura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AngajatId"] = new SelectList(_context.Angajati, "Id", "Id", factura.AngajatId);
            ViewData["CompanieId"] = new SelectList(_context.Companii, "Id", "Id", factura.CompanieId);
            ViewData["Numar_FacturaId"] = new SelectList(_context.Numar_Facturi, "Id", "Id", factura.Numar_FacturaId);
            return View(factura);
        }

        // GET: Facturi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factura = await _context.Facturi.FindAsync(id);
            if (factura == null)
            {
                return NotFound();
            }
            ViewData["AngajatId"] = new SelectList(_context.Angajati, "Id", "Nume_Prenume", factura.AngajatId);
            ViewData["CompanieId"] = new SelectList(_context.Companii, "Id", "Nume", factura.CompanieId);
            ViewData["Numar_FacturaId"] = new SelectList(_context.Numar_Facturi, "Id", "Id", factura.Numar_FacturaId);
            return View(factura);
        }

        // POST: Facturi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CIM_Angajat,Nume_Angajat,Data,Serie,Numar_Document,Tip_Document,Suma_Totala,Suma_Platita,Restanta,AngajatId,CompanieId,Numar_FacturaId")] Factura factura)
        {
            if (id != factura.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(factura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacturaExists(factura.Id))
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
            ViewData["AngajatId"] = new SelectList(_context.Angajati, "Id", "Id", factura.AngajatId);
            ViewData["CompanieId"] = new SelectList(_context.Companii, "Id", "Id", factura.CompanieId);
            ViewData["Numar_FacturaId"] = new SelectList(_context.Numar_Facturi, "Id", "Id", factura.Numar_FacturaId);
            return View(factura);
        }

        // GET: Facturi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factura = await _context.Facturi
                .Include(f => f.Angajat)
                .Include(f => f.Companie)
                .Include(f => f.Numar_Factura)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (factura == null)
            {
                return NotFound();
            }

            return View(factura);
        }

        // POST: Facturi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var factura = await _context.Facturi.FindAsync(id);
            _context.Facturi.Remove(factura);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FacturaExists(int id)
        {
            return _context.Facturi.Any(e => e.Id == id);
        }
    }
}
