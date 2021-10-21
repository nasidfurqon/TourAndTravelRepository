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
            var movies = from m in _context.tempats
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
        public async Task<IActionResult> Login([Bind("ID,Name,PhoneNumber,Address,Email,Pasword")] Customers customer)
        {
            if (ModelState.IsValid)
            {
                _context.customers.Add(customer);
                await _context.SaveChangesAsync();
                 return RedirectToAction("ucapanSelamat");
            }
            return View(customer);
        }
        public IActionResult Contact()
        {
            return View(_context.contacts.ToList());
        }
        public IActionResult Tempat()
        {
            return View(_context.tempats.ToList());
        }
        public IActionResult Category()
        {
            return View(_context.categories.ToList());
        }
        public  IActionResult Show(int? id)
        {
            if( id == null)
            {
                return NotFound();
            }

            var tempat =_context.destinations.Find(id);
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

            var tempat =_context.categories.Find(id);
            if (tempat ==null)
            {
                return NotFound();
            }
            return View(tempat);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Transaksi([Bind("ID,DestinationID,CustomersId,Date,Price")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                _context.transactions.Add(transaction);
                await _context.SaveChangesAsync();
                 return RedirectToAction("ucapanSelamat");
            }
            return View(transaction);
        }
    }
}