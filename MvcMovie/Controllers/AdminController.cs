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
            var tempat = from m in _context.Destinations
            select m;
            tempat=tempat.Where(s =>s.Verify==true);
            return View(tempat.ToList());
        }
        public IActionResult StatusPembelian()
        {
            return View(_context.Transactions.ToList());
        }
        public IActionResult Konfirmasi(int? id)
        {
            var tempat=_context.Destinations.Find(id);
             if (id == null)
                {
                    return NotFound();
                }
            if (tempat==null)
            {

                return NotFound();
            }

            return View(tempat);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Konfirmasi(int id, [Bind("Id,CategoryId,Place,Kota,Price,Deskripsi,Verify")] Destination destination)
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
                        if (!ListExists(destination.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction("Pembaruan");
                }
                return View(destination);
            }
        private bool ListExists(int id)
        {
            var tempat =_context.Destinations.Find(id);
            return tempat!=null;
        }
        public IActionResult Pembaruan()
        {
            var tempat = from m in _context.Destinations
            select m;
            tempat=tempat.Where(s =>s.Verify==false);
            return View(tempat.ToList());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CategoryId,Place,Kota,Price,Deskripsi,Verify")] Destination destination)
        {
            if (ModelState.IsValid)
            {
                _context.Destinations.Add(destination);
                await _context.SaveChangesAsync();
                return RedirectToAction("Tempat");
            }
            return View(destination);
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}