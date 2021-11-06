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
        public IActionResult CreateDeskripsi()
        {
            return View();
        }
        public async Task<IActionResult> Tempat(string searchString)
        {
            var movies = from m in _context.Destinations
            select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Place.Contains(searchString));
            }
            movies=movies.Where(s =>s.Verify=="iya");
            return View(await movies.ToListAsync());
        }

        // POST: Movies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateDeskripsi([Bind("Id,CategoryId,Place,Kota,Price,Deskripsi")] Destination destination)
        {
            if (ModelState.IsValid)
            {
                _context.Destinations.Add(destination);
                await _context.SaveChangesAsync();
                return RedirectToAction("UcapanBerhasil");
            }
            return View(destination);
        }
       
        public IActionResult Edit(int? id)
        {
            var movie=_context.Destinations.Find(id);
             if (id == null)
                {
                    return NotFound();
                }
            if (movie==null)
            {

                return NotFound();
            }

            return View(movie);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CategoryId,Place,Kota,Price,Deskripsi")] Destination destination)
            {
                if (id != destination.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(destination);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!MovieExists(destination.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction("Tempat");
                }
                return View(destination);
            }
        private bool MovieExists(int id)
        {
            var movie =_context.Destinations.Find(id);
            return movie!=null;
        }
        public  IActionResult Delete(int? id)
        {
            if( id == null)
            {
                return NotFound();
            }

            var movie =_context.Destinations.Find(id);
            if (movie ==null)
            {
                return NotFound();
            }
            return View(movie);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Destinations.FindAsync(id);
            _context.Destinations.Remove(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction("Tempat");
        }

        public IActionResult UcapanBerhasil()
        {
            return View();
        }

       public IActionResult Verified (int id)
        {
            var Verified =_context.Destinations.Find(id);
            Verified.Verify="iya";
            _context.Destinations.Add(Verified);
            _context.SaveChanges();
            return RedirectToAction("Tempat");
        }
    }
}