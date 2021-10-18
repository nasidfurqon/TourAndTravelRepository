using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcMovie.Data;

namespace MvcMovie.Controllers
{
    public class TourAndTravelController : Controller
    {
        MvcMovieDbContext _context;
        public TourAndTravelController (MvcMovieDbContext context)
        {
            _context=context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
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
    }
}