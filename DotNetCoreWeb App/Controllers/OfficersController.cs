using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DotNetCoreWeb_App.Data;
using DotNetCoreWeb_App.Models;

namespace DotNetCoreWeb_App.Controllers
{
    public class OfficersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OfficersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Officers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Officers.ToListAsync());
        }

        // GET: Officers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var officers = await _context.Officers
                .FirstOrDefaultAsync(m => m.officer_id == id);
            if (officers == null)
            {
                return NotFound();
            }

            return View(officers);
        }

        // GET: Officers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Officers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("officer_id,last,first,precinct,badge,phone,status")] Officers officers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(officers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(officers);
        }

        // GET: Officers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var officers = await _context.Officers.FindAsync(id);
            if (officers == null)
            {
                return NotFound();
            }
            return View(officers);
        }

        // POST: Officers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("officer_id,last,first,precinct,badge,phone,status")] Officers officers)
        {
            if (id != officers.officer_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(officers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OfficersExists(officers.officer_id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(officers);
        }

        // GET: Officers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var officers = await _context.Officers
                .FirstOrDefaultAsync(m => m.officer_id == id);
            if (officers == null)
            {
                return NotFound();
            }

            return View(officers);
        }

        // POST: Officers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var officers = await _context.Officers.FindAsync(id);
            _context.Officers.Remove(officers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OfficersExists(int id)
        {
            return _context.Officers.Any(e => e.officer_id == id);
        }
    }
}
