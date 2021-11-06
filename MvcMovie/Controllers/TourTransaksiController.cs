using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    [Authorize]
    public class TourTransaksiController : Controller
    {
        private readonly ILogger<TourItemController> _logger;
        private UserManager<Customers> _userManager;
        public TourTransaksiController(ILogger<TourItemController> logger, MvcMovieDbContext context, UserManager<Customers> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }
        MvcMovieDbContext _context;

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([Bind("Id,DestinationID,CustomersId,Date,Price,UserName")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                _context.Transactions.Add(transaction);
                await _context.SaveChangesAsync();
                 return RedirectToAction("TransaksiBerhasil");
            }
            return View(transaction);
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult TransaksiBerhasil()
        {
            return View();
        }
    }
}