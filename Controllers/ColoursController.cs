using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RemnantsProject.Data;
using RemnantsProject.Models;


namespace RemnantsProject.Controllers
{
    public class ColoursController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ColoursController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _webHostEnvironment = env;
        }

        // GET: Colours
        public async Task<IActionResult> Index()
        {
            return _context.Colours != null ?
                        View(await _context.Colours.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Colours'  is null.");
        }

        // GET: Colours/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Colours == null)
            {
                return NotFound();
            }

            var colour = await _context.Colours
                .FirstOrDefaultAsync(m => m.Id == id);
            if (colour == null)
            {
                return NotFound();
            }

            return View(colour);
        }

        // GET: Colours/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Colours/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Type, UploadedImage")] ColourViewModel colour)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (colour.UploadedImage == null)
                    {
                        colour.Picture = null;
                    }
                    else
                    {
                        colour.Picture = UploadFile(colour.UploadedImage);
                    }
                    _context.Add(colour);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Picture", ex.Message);
            }
            return View(colour);
        }

        // GET: Colours/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Colours == null)
            {
                return NotFound();
            }

            var colour = await _context.Colours.FindAsync(id);
            if (colour == null)
            {
                return NotFound();
            }
            return View(colour);
        }

        // POST: Colours/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Type, UploadedImage")] ColourViewModel colour)
        {
            if (id != colour.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(colour);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ColourExists(colour.Id))
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
            return View(colour);
        }

        // GET: Colours/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Colours == null)
            {
                return NotFound();
            }

            var colour = await _context.Colours
                .FirstOrDefaultAsync(m => m.Id == id);
            if (colour == null)
            {
                return NotFound();
            }

            return View(colour);
        }

        // POST: Colours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Colours == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Colours'  is null.");
            }
            var colour = await _context.Colours.FindAsync(id);
            if (colour != null)
            {
                _context.Colours.Remove(colour);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ColourExists(int id)
        {
            return (_context.Colours?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        private String UploadFile(IFormFile uploadedFile)
        {
            String ImageExtention;
            String ImageName, FullImageName;

            Random rnd = new Random();
            if (uploadedFile.ContentType == "image/png")
            {
                ImageExtention = ".png";
            }
            else if (uploadedFile.ContentType == "image/jpeg")
            {
                ImageExtention = ".jpg";
            }
            else if (uploadedFile.ContentType == "image/gif")
            {
                ImageExtention = ".gif";
            }
            else
            {
                throw new Exception("Unacceptable file type!");
            }
            do
            {
                int number = rnd.Next(100000, 999999);
                ImageName = "img" + number + ImageExtention;
                FullImageName = Path.Combine(_webHostEnvironment.WebRootPath, "images/RemnantSamples", ImageName);
            } while (System.IO.File.Exists(FullImageName));

            using (FileStream file = new FileStream(FullImageName, FileMode.Create))
            {
                uploadedFile.CopyTo(file);
            }
            return ImageName;

        }
    }
}
