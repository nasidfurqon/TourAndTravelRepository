using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Encodings.Web;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcMovie.Data;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace MvcMovie.Controllers
{
    public class TourAndTravelController : Controller
    {
        
        private readonly ILogger<TourAndTravelController> _logger;
        private UserManager<Customers> _userManager;
        public TourAndTravelController(ILogger<TourAndTravelController> logger, MvcMovieDbContext context, UserManager<Customers> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }
        MvcMovieDbContext _context;  
        // POST: Movies/Create
        [Authorize]
       
        public async Task<IActionResult> Tempat(string searchString)
        {
            var tempat = from m in _context.Destinations
            select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                tempat = tempat.Where(s => s.Place.Contains(searchString));
            }
            tempat=tempat.Where(s =>s.Verify==true);
            return View(await tempat.ToListAsync());
        }

       public IActionResult CreateDeskripsi()
        {
            var kategori = from m in _context.Categories
            select m;

            IQueryable<Category> NameQuery = from m in _context.Categories
            select m;
            
            IQueryable<int> IdQuery = from m in _context.Categories
            select m.Id;

            var destinasiPlaceVM = new CreateViewModel
            {
                Names = new SelectList(NameQuery.Distinct().ToList(),"Id","Name")
            };
            return View(destinasiPlaceVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateDeskripsi([Bind(Prefix ="Destinasi")] Destination destination)
        {
            if (ModelState.IsValid)
            {
                _context.Destinations.Add(destination);
                await _context.SaveChangesAsync();
                return RedirectToAction("UcapanBerhasil");
            }
            IQueryable<Category> NameQuery = from m in _context.Categories
            select m;
            var destinasi = new CreateViewModel
            {
                Names = new SelectList(NameQuery.Distinct().ToList(),"Id","Name"),
                Destinasi = destination
            };
            return View(destinasi);
        }
        public IActionResult UcapanBerhasil()
        {
            return View();
        }

       public IActionResult Verified (int id)
        {
            var Verified =_context.Destinations.Find(id);
            Verified.Verify=true;
            _context.Destinations.Add(Verified);
            _context.SaveChanges();
            return RedirectToAction("Tempat");
        }
    }
}