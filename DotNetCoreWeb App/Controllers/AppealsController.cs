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
    public class AppealsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AppealsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Appeals
        public async Task<IActionResult> Index()
        {
            return View(await _context.Appeals.ToListAsync());
        }

        // GET: Appeals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appeals = await _context.Appeals
                .FirstOrDefaultAsync(m => m.appeal_id == id);
            if (appeals == null)
            {
                return NotFound();
            }

            return View(appeals);
        }

        // GET: Appeals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Appeals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("appeal_id,crime_id,filing_date,hearing_date,status")] Appeals appeals)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appeals);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(appeals);
        }

        // GET: Appeals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appeals = await _context.Appeals.FindAsync(id);
            if (appeals == null)
            {
                return NotFound();
            }
            return View(appeals);
        }

        // POST: Appeals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("appeal_id,crime_id,filing_date,hearing_date,status")] Appeals appeals)
        {
            if (id != appeals.appeal_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appeals);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppealsExists(appeals.appeal_id))
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
            return View(appeals);
        }

        // GET: Appeals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appeals = await _context.Appeals
                .FirstOrDefaultAsync(m => m.appeal_id == id);
            if (appeals == null)
            {
                return NotFound();
            }

            return View(appeals);
        }

        // POST: Appeals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appeals = await _context.Appeals.FindAsync(id);
            _context.Appeals.Remove(appeals);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppealsExists(int id)
        {
            return _context.Appeals.Any(e => e.appeal_id == id);
        }
    }
}
