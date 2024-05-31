using Microsoft.AspNetCore.Mvc;
using RemnantsProject.Data;
using RemnantsProject.Models;
using System.Diagnostics;

namespace RemnantsProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(ContactForm contactForm)
        {
            //if all fields are filled
            if (ModelState.IsValid)
            {
                _context.ContactForms.Add(contactForm);
                _context.SaveChanges();
                return RedirectToAction("FormSent");
            }
            return View(contactForm);
        }
        public IActionResult FormSent()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}