using Discos_EF.Data;
using Discos_EF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Discos_EF.Controllers
{
    public class DiscoController : Controller
    {
        private readonly DiscosDbContext _context;

        public DiscoController(DiscosDbContext context)
        {
            _context = context;
        }

        // GET: Disco
        public async Task<IActionResult> Index(string filtro)
        {

            var discosDbContext = _context.Discos.Include(d => d.Estilo).Include(d => d.TipoEdicion);
            var discosDbContextFiltro = await discosDbContext.ToListAsync();

            if (!string.IsNullOrEmpty(filtro))
            {
                discosDbContextFiltro = discosDbContextFiltro.FindAll(d => d.Titulo.ToUpper().Contains(filtro.ToUpper()));
            }

            ViewBag.filtro = filtro;
            return View(discosDbContextFiltro);
        }

        // GET: Disco/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disco = await _context.Discos
                .Include(d => d.Estilo)
                .Include(d => d.TipoEdicion)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (disco == null)
            {
                return NotFound();
            }

            return View(disco);
        }

        // GET: Disco/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Estilos = new SelectList(await _context.Estilos.ToListAsync(), "Id", "Descripcion");
            ViewBag.TipoEdiciones = new SelectList(await _context.TipoEdiciones.ToListAsync(), "Id", "Descripcion");
            return View();
        }

        // POST: Disco/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Disco disco)
        {
            if (ModelState.IsValid)
            {
                _context.Add(disco);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EstiloId"] = new SelectList(_context.Estilos, "Id", "Id", disco.EstiloId);
            ViewData["TipoEdicionId"] = new SelectList(_context.TipoEdiciones, "Id", "Id", disco.TipoEdicionId);
            return View(disco);
        }

        // GET: Disco/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.Estilos = new SelectList(await _context.Estilos.ToListAsync(), "Id", "Descripcion");
            ViewBag.TipoEdiciones = new SelectList(await _context.TipoEdiciones.ToListAsync(), "Id", "Descripcion");
            if (id == null)
            {
                return NotFound();
            }

            var disco = await _context.Discos.FindAsync(id);
            if (disco == null)
            {
                return NotFound();
            }
            ViewData["EstiloId"] = new SelectList(_context.Estilos, "Id", "Id", disco.EstiloId);
            ViewData["TipoEdicionId"] = new SelectList(_context.TipoEdiciones, "Id", "Id", disco.TipoEdicionId);
            return View(disco);
        }

        // POST: Disco/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,FechaLanzamiento,CantidadCanciones,UrlTapa,EstiloId,TipoEdicionId")] Disco disco)
        {
            if (id != disco.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(disco);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiscoExists(disco.Id))
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
            ViewData["EstiloId"] = new SelectList(_context.Estilos, "Id", "Id", disco.EstiloId);
            ViewData["TipoEdicionId"] = new SelectList(_context.TipoEdiciones, "Id", "Id", disco.TipoEdicionId);
            return View(disco);
        }

        // GET: Disco/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disco = await _context.Discos
                .Include(d => d.Estilo)
                .Include(d => d.TipoEdicion)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (disco == null)
            {
                return NotFound();
            }

            return View(disco);
        }

        // POST: Disco/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var disco = await _context.Discos.FindAsync(id);
            if (disco != null)
            {
                _context.Discos.Remove(disco);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiscoExists(int id)
        {
            return _context.Discos.Any(e => e.Id == id);
        }
    }
}
