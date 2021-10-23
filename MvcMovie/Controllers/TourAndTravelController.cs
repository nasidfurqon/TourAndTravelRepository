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

namespace MvcMovie.Controllers
{
    public class TourAndTravelController : Controller
    {
        MvcMovieDbContext _context;
        public TourAndTravelController (MvcMovieDbContext context)
        {
            _context=context;
        }
        public IActionResult Index(string searchString)
        {
            var movies = from m in _context.Tempats
            select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.NamaTempat.Contains(searchString));
            }
            return View(movies);
            }      
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("ID,Email,Pasword")] Customers customer)
        {
            if (ModelState.IsValid)
            {
                _context.Customers.Add(customer);
                await _context.SaveChangesAsync();
                 return RedirectToAction("ucapanSelamat");
            }
            return View(customer);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registrasi([Bind("ID,Name,PhoneNumber,Address,Email,Pasword")] Customers customer)
        {
            if (ModelState.IsValid)
            {
                _context.Customers.Add(customer);
                await _context.SaveChangesAsync();
                 return RedirectToAction("ucapanSelamat");
            }
            return View(customer);
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
        public IActionResult ucapanSelamat()
        {
            return View();
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
                 return RedirectToAction("ucapanSelamat");
            }
            return View(transaction);
        }
        public IActionResult Registrasi()
        {
            return View();
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
    }
}
