using BndMSC.Data;
using BndMSC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BndMSC.Controllers
{
    public class BandasController : Controller
    {
        private readonly ApplicationDbContext db;

        public BandasController(ApplicationDbContext db)
        {
            this.db = db;

        }

        public async Task<IActionResult> Index()
        {
            return View(await db.Bandas.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var banda = await db.Bandas.FirstOrDefaultAsync(m => m.BandasId == id);
            if (banda == null)
            {
                return NotFound();
            }
            return View(banda);
        }

        //metodo de la vista

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Bandas Banda)
        {
            if (ModelState.IsValid)
            {
                db.Add(Banda);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Banda);
        }
        // Bandas Edit
        public async Task<IActionResult> Edit(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var Band = await db.Bandas.FindAsync(Id);

            if (Band == null)
            {
                return NotFound();
            }
            return View(Band);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int Id, Bandas Banda)
        {
            if (Id != Banda.BandasId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(Banda);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(Banda);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var banda = await db.Bandas.FirstOrDefaultAsync(m => m.BandasId == id);
            if (banda == null)
            {
                return NotFound();
            }
            return View(banda);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var band = await db.Bandas.FindAsync(id);
            db.Bandas.Remove(band);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
