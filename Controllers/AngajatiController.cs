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
    public class AngajatiController : Controller
    {
        private readonly EconomatContext _context;

        public AngajatiController(EconomatContext context)
        {
            _context = context;
        }


        // GET: Angajati
        public async Task<IActionResult> Index()
        {

            return View(await _context.Angajati.ToListAsync());

        }

        // GET: Angajati/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var angajat = await _context.Angajati
                .FirstOrDefaultAsync(m => m.Id == id);
            if (angajat == null)
            {
                return NotFound();
            }

            return View(angajat);
        }

        // GET: Angajati/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Angajati/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nume_Prenume,CIM,CNP,Sold,Restanta_Totala")] Angajat angajat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(angajat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(angajat);
        }

        // GET: Angajati/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var angajat = await _context.Angajati.FindAsync(id);
            if (angajat == null)
            {
                return NotFound();
            }
            return View(angajat);
        }

        // POST: Angajati/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nume_Prenume,CIM,CNP,Sold,Restanta_Totala")] Angajat angajat)
        {
            if (id != angajat.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(angajat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AngajatExists(angajat.Id))
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
            return View(angajat);
        }

        // GET: Angajati/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var angajat = await _context.Angajati
                .FirstOrDefaultAsync(m => m.Id == id);
            if (angajat == null)
            {
                return NotFound();
            }

            return View(angajat);
        }

        // POST: Angajati/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var angajat = await _context.Angajati.FindAsync(id);
            _context.Angajati.Remove(angajat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AngajatExists(int id)
        {
            return _context.Angajati.Any(e => e.Id == id);
        }

    }
}
