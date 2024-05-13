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
    public class CommandefsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CommandefsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Commandefs
        public async Task<IActionResult> Index()
        {
            return View(await _context.commandef.ToListAsync());
        }

        // GET: Commandefs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commandef = await _context.commandef
                .FirstOrDefaultAsync(m => m.IdCommande == id);
            if (commandef == null)
            {
                return NotFound();
            }

            return View(commandef);
        }

        // GET: Commandefs/Create
        public IActionResult Create()
        {
            // Récupérer la liste des clients depuis la base de données
            var clients = _context.Client.ToList();

            // Créer une liste de SelectListItems pour la liste déroulante
            var clientList = clients.Select(c => new SelectListItem
            {
                Text = c.Nom,
                Value = c.Nom // Ou Value = c.IdClient.ToString() si vous souhaitez utiliser l'ID du client
            }).ToList(); // Convertir en liste

            // Ajouter une option vide pour la sélection par défaut
            clientList.Insert(0, new SelectListItem { Text = "Sélectionnez un client", Value = "" });

            // Passer la liste des clients à la vue
            ViewBag.ClientList = clientList;

            return View();
        }


        // POST: Commandefs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCommande,ClientName,telclient,nomlivreur,DateCommande,food")] Commandef commandef)
        {
            if (ModelState.IsValid)
            {
                _context.Add(commandef);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(commandef);
        }

        // GET: Commandefs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commandef = await _context.commandef.FindAsync(id);
            if (commandef == null)
            {
                return NotFound();
            }
            return View(commandef);
        }

        // POST: Commandefs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCommande,ClientName,telclient,nomlivreur,DateCommande,food")] Commandef commandef)
        {
            if (id != commandef.IdCommande)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(commandef);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommandefExists(commandef.IdCommande))
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
            return View(commandef);
        }

        // GET: Commandefs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commandef = await _context.commandef
                .FirstOrDefaultAsync(m => m.IdCommande == id);
            if (commandef == null)
            {
                return NotFound();
            }

            return View(commandef);
        }

        // POST: Commandefs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var commandef = await _context.commandef.FindAsync(id);
            if (commandef != null)
            {
                _context.commandef.Remove(commandef);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CommandefExists(int id)
        {
            return _context.commandef.Any(e => e.IdCommande == id);
        }
    }
}
