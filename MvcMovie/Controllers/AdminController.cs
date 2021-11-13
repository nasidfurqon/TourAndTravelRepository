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
        public IActionResult Create()
        {
            var kategori = from m in _context.Categories
            select m;

            IQueryable<Category> NameQuery = from m in _context.Categories
            select m;
            
            IQueryable<int> IdQuery = from m in _context.Categories
            select m.Id;

            var destinasiPlaceVM = new CreateViewModel
            {
                Names = new SelectList(NameQuery.Distinct().ToList(),"Id","Name")
            };
            return View(destinasiPlaceVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind(Prefix ="Destinasi")] Destination destination)
        {
            if (ModelState.IsValid)
            {
                _context.Destinations.Add(destination);
                await _context.SaveChangesAsync();
                return RedirectToAction("Tempat");
            }
            IQueryable<Category> NameQuery = from m in _context.Categories
            select m;
            var destinasi = new CreateViewModel
            {
                Names = new SelectList(NameQuery.Distinct().ToList(),"Id","Name"),
                Destinasi = destination
            };
            return View(destinasi);
        }
        public  IActionResult Delete(int? id)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tempat = await _context.Destinations.FindAsync(id);
            _context.Destinations.Remove(tempat);
            await _context.SaveChangesAsync();
            return RedirectToAction("Tempat");
        }
        public  IActionResult DeleteRequest(int? id)
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmedDelete(int id)
        {
            var tempat = await _context.Destinations.FindAsync(id);
            _context.Destinations.Remove(tempat);
            await _context.SaveChangesAsync();
            return RedirectToAction("Pembaruan");
        }
        public  IActionResult Detail(int? id)
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
        public  IActionResult DetailTempat(int? id)
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
        public IActionResult Edit(int? id)
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,CategoryId,Place,Kota,Price,Deskripsi,Verify")] Destination destination)
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
                    return RedirectToAction("Tempat");
                }
                return View(destination);
            }
    }
}