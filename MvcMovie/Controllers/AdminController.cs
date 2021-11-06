using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private UserManager<Customers> _userManager;
        public AdminController(ILogger<AdminController> logger, MvcMovieDbContext context, UserManager<Customers> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }
        MvcMovieDbContext _context;
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Tempat()
        {
            return View(_context.Destinations.ToList());
        }
        public IActionResult StatusPembelian()
        {
            return View(_context.Transactions.ToList());
        }
        public IActionResult CekUpdate()
        {
            return View(_context.dataSementaras.ToList());
        }
        public  IActionResult Delete(int? id)
        {
            if( id == null)
            {
                return NotFound();
            }

            var movie =_context.dataSementaras.Find(id);
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
            var movie = await _context.dataSementaras.FindAsync(id);
            _context.dataSementaras.Remove(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction("Cekupdate");
        }

        public  IActionResult Add(int? id)
        {
            if( id == null)
            {
                return NotFound();
            }

            var movie =_context.dataSementaras.Find(id);
            if (movie ==null)
            {
                return NotFound();
            }
            return View(movie);
        }
    }
}