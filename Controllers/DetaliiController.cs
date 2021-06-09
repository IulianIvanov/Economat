using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Economat_v2.Data;
using Economat_v2.Models;
using System.Xml.Schema;

namespace Economat_v2.Controllers
{
    public class DetaliiController : Controller
    {
        private readonly EconomatContext _context;

        public DetaliiController(EconomatContext context)
        {
            _context = context;
        }

        // GET: Detalii
        public async Task<IActionResult> Index()
        {
            var economatContext = _context.Detalii.Include(d => d.Factura).Include(d => d.Produs);
            return View(await economatContext.ToListAsync());
        }

        // GET: Detalii/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detali = await _context.Detalii
                .Include(d => d.Factura)
                .Include(d => d.Produs)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detali == null)
            {
                return NotFound();
            }

            return View(detali);
        }

        // GET: Detalii/Create
        public IActionResult Create()
        {
            ViewData["FacturaId"] = new SelectList(_context.Facturi, "Id", "Id");
            ViewData["ProdusId"] = new SelectList(_context.Produse, "Id", "Nume");
            return View();
        }

        // POST: Detalii/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nume_Produs,Cantitate_Produs,Pret,Data,FacturaId,ProdusId")] Detali detali)
        {
            
            if (ModelState.IsValid)
            {
                _context.Add(detali);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FacturaId"] = new SelectList(_context.Facturi, "Id", "Id", detali.FacturaId);
            ViewData["ProdusId"] = new SelectList(_context.Produse, "Id", "Id", detali.ProdusId);
            
            

            return View(detali);
        }

        // GET: Detalii/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detali = await _context.Detalii.FindAsync(id);
            if (detali == null)
            {
                return NotFound();
            }
            ViewData["FacturaId"] = new SelectList(_context.Facturi, "Id", "Id", detali.FacturaId);
            ViewData["ProdusId"] = new SelectList(_context.Produse, "Id", "Nume", detali.ProdusId);
            return View(detali);
        }

        // POST: Detalii/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nume_Produs,Cantitate_Produs,Pret,Data,FacturaId,ProdusId")] Detali detali)
        {
            if (id != detali.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detali);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetaliExists(detali.Id))
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
            ViewData["FacturaId"] = new SelectList(_context.Facturi, "Id", "Id", detali.FacturaId);
            ViewData["ProdusId"] = new SelectList(_context.Produse, "Id", "Id", detali.ProdusId);
            return View(detali);
        }

        // GET: Detalii/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detali = await _context.Detalii
                .Include(d => d.Factura)
                .Include(d => d.Produs)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detali == null)
            {
                return NotFound();
            }

            return View(detali);
        }

        // POST: Detalii/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detali = await _context.Detalii.FindAsync(id);
            _context.Detalii.Remove(detali);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetaliExists(int id)
        {
            return _context.Detalii.Any(e => e.Id == id);
        }
    }
}
