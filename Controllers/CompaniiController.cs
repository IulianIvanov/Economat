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
    public class CompaniiController : Controller
    {
        private readonly EconomatContext _context;

        public CompaniiController(EconomatContext context)
        {
            _context = context;
        }

        // GET: Companii
        public async Task<IActionResult> Index()
        {
            return View(await _context.Companii.ToListAsync());
        }

        // GET: Companii/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companie = await _context.Companii
                .FirstOrDefaultAsync(m => m.Id == id);
            if (companie == null)
            {
                return NotFound();
            }

            return View(companie);
        }

        // GET: Companii/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Companii/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nume,Adresa,Telefon,Mail")] Companie companie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(companie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(companie);
        }

        // GET: Companii/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companie = await _context.Companii.FindAsync(id);
            if (companie == null)
            {
                return NotFound();
            }
            return View(companie);
        }

        // POST: Companii/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nume,Adresa,Telefon,Mail")] Companie companie)
        {
            if (id != companie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(companie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanieExists(companie.Id))
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
            return View(companie);
        }

        // GET: Companii/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companie = await _context.Companii
                .FirstOrDefaultAsync(m => m.Id == id);
            if (companie == null)
            {
                return NotFound();
            }

            return View(companie);
        }

        // POST: Companii/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var companie = await _context.Companii.FindAsync(id);
            _context.Companii.Remove(companie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompanieExists(int id)
        {
            return _context.Companii.Any(e => e.Id == id);
        }
    }
}
