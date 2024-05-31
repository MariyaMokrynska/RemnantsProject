using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RemnantsProject.Data;

namespace RemnantsProject.Controllers
{
    [Authorize(Roles= RemnantsProject.Data.Roles.ADMIN)]
    public class SurfaceTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SurfaceTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SurfaceTypes
        public async Task<IActionResult> Index()
        {
              return _context.SurfaceTypes != null ? 
                          View(await _context.SurfaceTypes.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.SurfaceTypes'  is null.");
        }

        // GET: SurfaceTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SurfaceTypes == null)
            {
                return NotFound();
            }

            var surfaceType = await _context.SurfaceTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (surfaceType == null)
            {
                return NotFound();
            }

            return View(surfaceType);
        }

        // GET: SurfaceTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SurfaceTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] SurfaceType surfaceType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(surfaceType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(surfaceType);
        }

        // GET: SurfaceTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SurfaceTypes == null)
            {
                return NotFound();
            }

            var surfaceType = await _context.SurfaceTypes.FindAsync(id);
            if (surfaceType == null)
            {
                return NotFound();
            }
            return View(surfaceType);
        }

        // POST: SurfaceTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] SurfaceType surfaceType)
        {
            if (id != surfaceType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(surfaceType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SurfaceTypeExists(surfaceType.Id))
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
            return View(surfaceType);
        }

        // GET: SurfaceTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SurfaceTypes == null)
            {
                return NotFound();
            }

            var surfaceType = await _context.SurfaceTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (surfaceType == null)
            {
                return NotFound();
            }

            return View(surfaceType);
        }

        // POST: SurfaceTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SurfaceTypes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.SurfaceTypes'  is null.");
            }
            var surfaceType = await _context.SurfaceTypes.FindAsync(id);
            if (surfaceType != null)
            {
                _context.SurfaceTypes.Remove(surfaceType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SurfaceTypeExists(int id)
        {
          return (_context.SurfaceTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
