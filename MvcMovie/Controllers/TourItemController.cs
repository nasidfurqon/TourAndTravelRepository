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
    public class TourItemController : Controller
    {
        private readonly ILogger<TourItemController> _logger;
        private UserManager<Customers> _userManager;
        public TourItemController(ILogger<TourItemController> logger, MvcMovieDbContext context, UserManager<Customers> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }
        MvcMovieDbContext _context;
        
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
        
    }
}