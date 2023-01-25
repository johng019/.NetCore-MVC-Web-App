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
    public class CrimesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CrimesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Crimes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Crimes.ToListAsync());
        }

        // GET: Crimes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var crimes = await _context.Crimes
                .FirstOrDefaultAsync(m => m.crime_id == id);
            if (crimes == null)
            {
                return NotFound();
            }

            return View(crimes);
        }

        // GET: Crimes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Crimes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("crime_id,criminal_id,classification,date_charged,status,hearing_date,appeal_cut_date,date_recorded")] Crimes crimes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(crimes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(crimes);
        }

        // GET: Crimes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var crimes = await _context.Crimes.FindAsync(id);
            if (crimes == null)
            {
                return NotFound();
            }
            return View(crimes);
        }

        // POST: Crimes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("crime_id,criminal_id,classification,date_charged,status,hearing_date,appeal_cut_date,date_recorded")] Crimes crimes)
        {
            if (id != crimes.crime_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(crimes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CrimesExists(crimes.crime_id))
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
            return View(crimes);
        }

        // GET: Crimes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var crimes = await _context.Crimes
                .FirstOrDefaultAsync(m => m.crime_id == id);
            if (crimes == null)
            {
                return NotFound();
            }

            return View(crimes);
        }

        // POST: Crimes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var crimes = await _context.Crimes.FindAsync(id);
            _context.Crimes.Remove(crimes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CrimesExists(int id)
        {
            return _context.Crimes.Any(e => e.crime_id == id);
        }
    }
}
