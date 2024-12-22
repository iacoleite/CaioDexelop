using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CaioDexelop.Data;
using CaioDexelop.Models;

namespace CaioDexelop.Controllers
{
    public class UtenteController : Controller
    {
        private readonly CaioDexelopContext _context;

        public UtenteController(CaioDexelopContext context)
        {
            _context = context;
        }

        // GET: Utente
        public async Task<IActionResult> Index(string searchString)
        {
            if (_context.Utente == null)
            {
                return NotFound();
            }
            var utentiCercati = from m in _context.Utente
                         select m;
            if (!String.IsNullOrEmpty(searchString))
            {
                utentiCercati = utentiCercati.Where(s => s.Nome!.ToLower().Contains(searchString.ToLower()) || s.Cognome!.ToLower().Contains(searchString.ToLower()) || s.Email!.ToLower().Contains(searchString.ToLower()));
            }
            return View(await utentiCercati.ToListAsync());
        }

        // GET: Utente/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utente = await _context.Utente
                .FirstOrDefaultAsync(m => m.Id == id);
            if (utente == null)
            {
                return NotFound();
            }

            return View(utente);
        }

        // GET: Utente/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Utentes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Cognome,Email")] Utente utente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(utente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(utente);
        }

        // GET: Utentes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utente = await _context.Utente.FindAsync(id);
            if (utente == null)
            {
                return NotFound();
            }
            return View(utente);
        }

        // POST: Utentes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Cognome,Email")] Utente utente)
        {
            if (id != utente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(utente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UtenteExists(utente.Id))
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
            return View(utente);
        }

        // GET: Utentes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utente = await _context.Utente
                .FirstOrDefaultAsync(m => m.Id == id);
            if (utente == null)
            {
                return NotFound();
            }

            return View(utente);
        }

        // POST: Utentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var utente = await _context.Utente.FindAsync(id);
            if (utente != null)
            {
                _context.Utente.Remove(utente);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UtenteExists(int id)
        {
            return _context.Utente.Any(e => e.Id == id);
        }


    }
}
