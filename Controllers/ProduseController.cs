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
    public class ProduseController : Controller
    {
        private readonly EconomatContext _context;

        
        public ProduseController(EconomatContext context)
        {
            _context = context;
        }

        //Sort
        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "nume_desc" : "";
            ViewBag.PriceSortParm = sortOrder == "Pret" ? "pret_desc" : "Pret";
            var produse = from p in _context.Produse
                           select p;
            if (!String.IsNullOrEmpty(searchString))
            {
                produse = produse.Where(p => p.Nume.Contains(searchString)
                                       || p.Categorie.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "nume_desc":
                    produse = produse.OrderByDescending(p => p.Nume);
                    break;
                case "Pret":
                    produse = produse.OrderBy(p => p.Pret_Unitate);
                    break;
                case "pret_desc":
                    produse = produse.OrderByDescending(p => p.Pret_Unitate);
                    break;
                default:
                    produse = produse.OrderBy(p => p.Nume);
                    break;
            }
            return View(produse.ToList());
        }

        // GET: Produse
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Produse.ToListAsync());
        //}

        // GET: Produse/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produs = await _context.Produse
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produs == null)
            {
                return NotFound();
            }

            return View(produs);
        }

        // GET: Produse/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Produse/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nume,Stoc,Pret_Unitate,Categorie")] Produs produs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(produs);
        }

        // GET: Produse/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produs = await _context.Produse.FindAsync(id);
            if (produs == null)
            {
                return NotFound();
            }
            return View(produs);
        }

        // POST: Produse/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nume,Stoc,Pret_Unitate,Categorie")] Produs produs)
        {
            if (id != produs.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdusExists(produs.Id))
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
            return View(produs);
        }

        // GET: Produse/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produs = await _context.Produse
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produs == null)
            {
                return NotFound();
            }

            return View(produs);
        }

        // POST: Produse/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produs = await _context.Produse.FindAsync(id);
            _context.Produse.Remove(produs);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdusExists(int id)
        {
            return _context.Produse.Any(e => e.Id == id);
        }
    }
}
