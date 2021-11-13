using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    [Authorize(Roles ="User")]

    public class TourTransaksiController : Controller
    {
        private readonly ILogger<TourTransaksiController> _logger;
        private UserManager<Customers> _userManager;
        public TourTransaksiController(ILogger<TourTransaksiController> logger, MvcMovieDbContext context, UserManager<Customers> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }
        MvcMovieDbContext _context;

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Transaksi([Bind(Prefix = "Transaksi")]Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                _context.Transactions.Add(transaction);
                await _context.SaveChangesAsync();
                 return RedirectToAction("TransaksiBerhasil");
            }
            
            var destination = from m in _context.Destinations
            select m;
            destination=destination.Where(s =>s.Verify==true);

            IQueryable<Destination> DestinasiQuery = from m in destination
            select m;

            var destinasiPlaceVM = new TransaksiViewModel
            {
                Places = new SelectList(DestinasiQuery,"Id","Place"),
                Prices =new SelectList(DestinasiQuery,"Price","Price")
            };

            return View(destinasiPlaceVM);
        }
        public IActionResult Transaksi()
        {
            var destination = from m in _context.Destinations
            select m;
            destination=destination.Where(s =>s.Verify==true);

            IQueryable<Destination> DestinasiQuery = from m in destination
            select m;

            var destinasiPlaceVM = new TransaksiViewModel
            {
                Places = new SelectList(DestinasiQuery,"Id","Place"),
                Prices =new SelectList(DestinasiQuery,"Price","Price")
            };

            return View(destinasiPlaceVM);
        }
        public IActionResult TransaksiBerhasil()
        {
            return View();
        }
    }
}