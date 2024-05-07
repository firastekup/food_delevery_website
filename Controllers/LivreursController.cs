using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using food_delevery_google_auth_Final_V.Data;
using food_delevery_google_auth_Final_V.Entity;

namespace food_delevery_google_auth_Final_V.Controllers
{
    public class LivreursController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LivreursController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Livreurs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Livreur.ToListAsync());
        }

        // GET: Livreurs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livreur = await _context.Livreur
                .FirstOrDefaultAsync(m => m.IdLivreur == id);
            if (livreur == null)
            {
                return NotFound();
            }

            return View(livreur);
        }

        // GET: Livreurs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Livreurs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdLivreur,Nom,Vehicule,ZoneLivraison,Disponibilite")] Livreur livreur)
        {
            if (ModelState.IsValid)
            {
                _context.Add(livreur);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(livreur);
        }

        // GET: Livreurs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livreur = await _context.Livreur.FindAsync(id);
            if (livreur == null)
            {
                return NotFound();
            }
            return View(livreur);
        }

        // POST: Livreurs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdLivreur,Nom,Vehicule,ZoneLivraison,Disponibilite")] Livreur livreur)
        {
            if (id != livreur.IdLivreur)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(livreur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LivreurExists(livreur.IdLivreur))
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
            return View(livreur);
        }

        // GET: Livreurs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livreur = await _context.Livreur
                .FirstOrDefaultAsync(m => m.IdLivreur == id);
            if (livreur == null)
            {
                return NotFound();
            }

            return View(livreur);
        }

        // POST: Livreurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var livreur = await _context.Livreur.FindAsync(id);
            if (livreur != null)
            {
                _context.Livreur.Remove(livreur);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LivreurExists(int id)
        {
            return _context.Livreur.Any(e => e.IdLivreur == id);
        }
    }
}
