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
        public IActionResult Index()
        {
            return View();
        }      
        public IActionResult Contact()
        {
            return View(_context.Contacts.ToList());
        }
        public IActionResult Tempat()
        {
            return View(_context.Tempats.ToList());
        }
        public IActionResult Category()
        {
            return View(_context.Categories.ToList());
        }
        [Authorize]
        public  IActionResult Show(int? id)
        {
            if( id == null)
            {
                return NotFound();
            }

            var tempat =_context.Destinations.Find(id);
            if (tempat ==null)
            {
                return NotFound();
            }
            return View(tempat);
        }

        public IActionResult Details(int? id)
        {
            if( id == null)
            {
                return NotFound();
            }
            
            var  destinasi =_context.Destinations.Where(x=>x.CategoryId==id);
            return View(destinasi);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Transaksi([Bind("ID,DestinationID,CustomersId,Date,Price")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                _context.Transactions.Add(transaction);
                await _context.SaveChangesAsync();
                 return RedirectToAction("TransaksiBerhasil");
            }
            return View(transaction);
        }
        public IActionResult Registrasi()
        {
            var userId = _userManager.GetUserId(User);
            var user = _context.Users.Find(userId);
            return View(user);
        }
        public IActionResult Transaksi()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        // POST: Movies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,NamaTempat,Kota")] Tempat tempat)
        {
            if (ModelState.IsValid)
            {
                _context.Tempats.Add(tempat);
                await _context.SaveChangesAsync();
                return RedirectToAction("ucapanBerhasil");
            }
            return View(tempat);
        }
        public IActionResult CreateDeskripsi()
        {
            return View();
        }

        // POST: Movies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateDeskripsi([Bind("ID,CategoryId,Place,Price,Deskripsi")] Destination destination)
        {
            if (ModelState.IsValid)
            {
                _context.Destinations.Add(destination);
                await _context.SaveChangesAsync();
                return RedirectToAction("Tempat");
            }
            return View(destination);
        }
        public IActionResult ucapanBerhasil()
        {
            return View();
        }
        public IActionResult TransaksiBerhasil()
        {
            return View();
        }
    }
}
