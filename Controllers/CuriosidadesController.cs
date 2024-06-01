using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SeaKids.Data;
using SeaKids.Models;

namespace SeaKids.Controllers
{
    public class CuriosidadesController : Controller
    {
        private readonly DataContext _context;

        public CuriosidadesController(DataContext context)
        {
            _context = context;
        }

        // GET: Curiosidades
        public async Task<IActionResult> Index()
        {
            return View(await _context.Curiosidades.ToListAsync());
        }

        // GET: Curiosidades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curiosidade = await _context.Curiosidades
                .FirstOrDefaultAsync(m => m.Id == id);
            if (curiosidade == null)
            {
                return NotFound();
            }

            return View(curiosidade);
        }

        // GET: Curiosidades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Curiosidades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Imagem,Texto")] Curiosidade curiosidade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(curiosidade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(curiosidade);
        }

        // GET: Curiosidades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curiosidade = await _context.Curiosidades.FindAsync(id);
            if (curiosidade == null)
            {
                return NotFound();
            }
            return View(curiosidade);
        }

        // POST: Curiosidades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Imagem,Texto")] Curiosidade curiosidade)
        {
            if (id != curiosidade.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(curiosidade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CuriosidadeExists(curiosidade.Id))
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
            return View(curiosidade);
        }

        // GET: Curiosidades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curiosidade = await _context.Curiosidades
                .FirstOrDefaultAsync(m => m.Id == id);
            if (curiosidade == null)
            {
                return NotFound();
            }

            return View(curiosidade);
        }

        // POST: Curiosidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var curiosidade = await _context.Curiosidades.FindAsync(id);
            if (curiosidade != null)
            {
                _context.Curiosidades.Remove(curiosidade);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CuriosidadeExists(int id)
        {
            return _context.Curiosidades.Any(e => e.Id == id);
        }
    }
}
