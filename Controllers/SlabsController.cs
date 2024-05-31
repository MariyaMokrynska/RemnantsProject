using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RemnantsProject.Data;
using Microsoft.EntityFrameworkCore;
using RemnantsProject.Models;
using Microsoft.AspNetCore.Authorization;

namespace RemnantsProject.Controllers
{
    public class SlabsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SlabsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Slabs
        public async Task<IActionResult> Index(Models.SlabSearch slabSearch)
        {
            IQueryable<Data.Slab> applicationDbContext = _context.Slabs.Include(s => s.Colour).Include(s => s.Manufacturer).Include(s => s.SurfaceType);
            if (slabSearch != null)
            {
                if (slabSearch.SoldState > 0)
                {
                    applicationDbContext = applicationDbContext.Where(sl => sl.State == slabSearch.SoldState);
                }
                if (slabSearch.MinLength > 0)
                {
                    applicationDbContext = applicationDbContext.Where(sl => sl.Length >= slabSearch.MinLength);
                }
                if (slabSearch.MaxLength > 0)
                {
                    applicationDbContext = applicationDbContext.Where(sl => sl.Length <= slabSearch.MaxLength);
                }
                if (slabSearch.MinWidth > 0)
                {
                    applicationDbContext = applicationDbContext.Where(sl => sl.Width >= slabSearch.MinWidth);
                }
                if (slabSearch.MaxWidth > 0)
                {
                    applicationDbContext = applicationDbContext.Where(sl => sl.Width <= slabSearch.MaxWidth);
                }
                if (slabSearch.MinPrice > 0)
                {
                    applicationDbContext = applicationDbContext.Where(sl => sl.Price >= slabSearch.MinPrice);
                }
                if (slabSearch.MaxPrice > 0)
                {
                    applicationDbContext = applicationDbContext.Where(sl => sl.Price <= slabSearch.MaxPrice);
                }
                if (slabSearch.Thickness > 0)
                {
                    applicationDbContext = applicationDbContext.Where(sl => sl.Thickness == slabSearch.Thickness);
                }
            }

            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Slabs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Slabs == null)
            {
                return NotFound();
            }

            var slab = await _context.Slabs
                .Include(s => s.Colour)
                .Include(s => s.Manufacturer)
                .Include(s => s.SurfaceType)
                .FirstOrDefaultAsync(m => m.SlabId == id);
            if (slab == null)
            {
                return NotFound();
            }

            return View(slab);
        }

        // GET: Slabs/Create
        public IActionResult Create()
        {
            ViewData["ColorId"] = new SelectList(_context.Colours, "Id", "Name");
            ViewData["ManufacturerId"] = new SelectList(_context.Manufacturers, "Id", "Name");
            ViewData["SurfaceTypeId"] = new SelectList(_context.SurfaceTypes, "Id", "Name");
            return View();
        }

        // POST: Slabs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Slab slab)
        {
            if (ModelState.IsValid)
            {
                _context.Add(slab);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ColorId"] = new SelectList(_context.Colours, "Id", "Name", slab.ColorId);
            ViewData["ManufacturerId"] = new SelectList(_context.Manufacturers, "Id", "Name", slab.ManufacturerId);
            ViewData["SurfaceTypeId"] = new SelectList(_context.SurfaceTypes, "Id", "Name", slab.SurfaceTypeId);
            return View(slab);
        }

        // GET: Slabs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Slabs == null)
            {
                return NotFound();
            }

            var slab = await _context.Slabs.FindAsync(id);
            if (slab == null)
            {
                return NotFound();
            }
            ViewData["ColorId"] = new SelectList(_context.Colours, "Id", "Name", slab.ColorId);
            ViewData["ManufacturerId"] = new SelectList(_context.Manufacturers, "Id", "Name", slab.ManufacturerId);
            ViewData["SurfaceTypeId"] = new SelectList(_context.SurfaceTypes, "Id", "Name", slab.SurfaceTypeId);
            return View(slab);
        }

        // POST: Slabs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Slab slab)
        {
            if (id != slab.SlabId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(slab);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SlabExists(slab.SlabId))
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
            ViewData["ColorId"] = new SelectList(_context.Colours, "Id", "Name", slab.ColorId);
            ViewData["ManufacturerId"] = new SelectList(_context.Manufacturers, "Id", "Name", slab.ManufacturerId);
            ViewData["SurfaceTypeId"] = new SelectList(_context.SurfaceTypes, "Id", "Name", slab.SurfaceTypeId);
            return View(slab);
        }

        // GET: Slabs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Slabs == null)
            {
                return NotFound();
            }

            var slab = await _context.Slabs
                .Include(s => s.Colour)
                .Include(s => s.Manufacturer)
                .Include(s => s.SurfaceType)
                .FirstOrDefaultAsync(m => m.SlabId == id);
            if (slab == null)
            {
                return NotFound();
            }

            return View(slab);
        }

        // POST: Slabs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Slabs == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Slabs'  is null.");
            }
            var slab = await _context.Slabs.FindAsync(id);
            if (slab != null)
            {
                _context.Slabs.Remove(slab);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SlabExists(int id)
        {
            return (_context.Slabs?.Any(e => e.SlabId == id)).GetValueOrDefault();
        }
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Hold(int slabId, string HoldCustomerName)
        {
            if (slabId > 0 && HoldCustomerName != "")
            {
                Slab slab = _context.Slabs.FirstOrDefault(s => s.SlabId == slabId);
                if (slab.HoldCustomerId != null && slab.HoldDueDate >= DateTime.Today)
                {
                    return View("Error", new ErrorViewModel() { RequestId = "Slab is not available." });
                }
                if(!String.IsNullOrEmpty(slab.PayConfirmationNumber) || slab.SlabPickedUpDate != null)
                {
                    return View("Error", new ErrorViewModel() { RequestId = "Slab was already paid or picked up." });
                }
                slab.HoldDueDate = DateTime.Today.AddDays(3);
                slab.HoldCustomerName = HoldCustomerName;
                string userLogin = HttpContext.User.Identity.Name;
                User user = await _context.Users.FirstOrDefaultAsync(u => u.PhoneNumber == userLogin);
                if (user == null)
                {
                    return View("Error", new ErrorViewModel() { RequestId = "User not found" });
                }
                slab.HoldCustomerId = user.Id;
                _context.Slabs.Update(slab);
                _context.SaveChanges();
                return RedirectToAction("Details", "Slabs", new { id = slabId });
            }
            return View("Error", new ErrorViewModel() { RequestId = "Customer Name can not be empty." });
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Payment(int slabId, string PaymentConfirmationNumber)
        {
            if (slabId > 0 && PaymentConfirmationNumber != "")
            {
                Slab slab = _context.Slabs.FirstOrDefault(s => s.SlabId == slabId);
                if (!String.IsNullOrEmpty(slab.PayConfirmationNumber))
                {
                    return View("Error", new ErrorViewModel() { RequestId = "Payment was already made." });
                }
                slab.PayConfirmationNumber = PaymentConfirmationNumber;
                
                string userLogin = HttpContext.User.Identity.Name;
                User user = await _context.Users.FirstOrDefaultAsync(u => u.PhoneNumber == userLogin);
                if (user == null)
                {
                    return View("Error", new ErrorViewModel() { RequestId = "User not found." });
                }
                slab.EmployeeIdReceivedPayment = user.Id;
                slab.DateOfPayment = DateTime.Now;
                _context.Slabs.Update(slab);
                _context.SaveChanges();
                return RedirectToAction("Details", "Slabs", new { id = slabId });
            }
            return View("Error", new ErrorViewModel() { RequestId = "Slab is not selected or payment confirmation number is empty." });
        }
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PickUpDate(int slabId)
        {
            if (slabId > 0)
            {
                Slab slab = _context.Slabs.FirstOrDefault(s => s.SlabId == slabId);
                if(String.IsNullOrEmpty(slab.PayConfirmationNumber))
                {
                    return View("Error", new ErrorViewModel() { RequestId = "Payment was not made. You can not pick up the slab!" });
                }
                if (slab.SlabPickedUpDate != null)
                {
                    return View("Error", new ErrorViewModel() { RequestId = "Slab was already picked up." });
                }
                slab.SlabPickedUpDate = DateTime.Now;
                string userLogin = HttpContext.User.Identity.Name;
                User user = await _context.Users.FirstOrDefaultAsync(u => u.PhoneNumber == userLogin);
                if (user == null)
                {
                    return View("Error", new ErrorViewModel() { RequestId = "User not found" });
                }
                slab.EmployeeIdDeliveringSlab = user.Id;
                _context.Slabs.Update(slab);
                _context.SaveChanges();
                return RedirectToAction("Details", "Slabs", new { id = slabId });
            }
            return View("Error", new ErrorViewModel() { RequestId = "Slab is not selected." });
        }
    }
}
